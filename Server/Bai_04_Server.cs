using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Bai_04_Server : Form
    {
        public Bai_04_Server()
        {
            InitializeComponent();
        }

        TcpListener listener;
        private static List<TcpClient> clients = new List<TcpClient>();
        private static string contentChat = ""; // Nội dung của đoạn Chat
        private bool isListening = false;
        private async void button_Listen_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                MessageBox.Show("Server đang lắng nghe", "Server Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                    listener = new TcpListener(ipEnd);
                    listener.Start();
                    textBox_Editor.Text = $"Server is running on {ipEnd.Address}:{ipEnd.Port}\r\n";
                    isListening = true;
                    while (isListening)
                    {
                        TcpClient client = await listener.AcceptTcpClientAsync();
                        IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                        lock (clients)
                        {
                            BroadcastUpdateAsync(contentChat + "Có thêm một người tham gia vào đoạn chat\r\n", client);
                            clients.Add(client);
                            textBox_Editor.AppendText($"New client connected from: {clientEndPoint.Address}: {clientEndPoint.Port}\r\n");
                        }
                        _ = Task.Run(() => HandleClientAsync(client));
                    }
                }
                catch (Exception ex) { 
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            // Gửi nội dung hiện tại tới client mới
            byte[] contentBuffer = Encoding.UTF8.GetBytes(contentChat);
            await stream.WriteAsync(contentBuffer, 0, contentBuffer.Length);

            // Lắng nghe các tin nhắn từ client này
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    // Chuyển đổi tin nhắn nhận được từ client thành chuỗi
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Cập nhật nội dung chat chung (tùy theo cách bạn muốn quản lý nội dung chat
                    contentChat += message;

                    IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    textBox_Editor.AppendText($"{clientEndPoint.Address}:{clientEndPoint.Port}: " + message);
                    // Broadcast tin nhắn đến các client khác
                    await BroadcastUpdateAsync(contentChat, client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý client: " + ex.Message, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ngắt kết nối client và loại bỏ khỏi danh sách
                lock (clients)
                {
                    clients.Remove(client);
                }


                client.Close();
            }
        }

        private static async Task BroadcastUpdateAsync(string update, TcpClient sender)
        {
            byte[] updateBuffer = Encoding.UTF8.GetBytes(update);
            List<TcpClient> clientsCopy;

            lock (clients)
            {
                // Tạo một bản sao của danh sách clients
                clientsCopy = new List<TcpClient>(clients);
            }

            List<Task> tasks = new List<Task>();
            foreach (TcpClient client in clientsCopy)
            {
                if (client != sender)
                {
                    NetworkStream stream = client.GetStream();
                    tasks.Add(stream.WriteAsync(updateBuffer, 0, updateBuffer.Length));
                }
            }

            await Task.WhenAll(tasks);
        }

        private async void button_Stop_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                // Gửi thông báo đến tất cả client rằng server sẽ đóng
                string shutdownMessage = "Server đang đóng. Vui lòng thoát khỏi phòng chat.\r\n";
                byte[] messageBuffer = Encoding.UTF8.GetBytes(shutdownMessage);
                isListening = false;

                List<TcpClient> disconnectedClients = new List<TcpClient>();

                foreach (var client in clients)
                {
                    try
                    {
                        // Kiểm tra xem client có còn kết nối không
                        if (client.Connected)
                        {
                            // Gửi thông báo đến client
                            await client.GetStream().WriteAsync(messageBuffer, 0, messageBuffer.Length);
                        }
                        else
                        {
                            disconnectedClients.Add(client);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Lỗi khi gửi thông báo đến client: {ex.Message}",
                            "Server Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        disconnectedClients.Add(client); // Thêm client vào danh sách ngắt kết nối
                    }
                }

                // Đợi 5 giây để đảm bảo tất cả client nhận được thông báo
                await Task.Delay(5000);

                // Đóng tất cả các kết nối client
                foreach (var client in clients)
                {
                    try
                    {
                        if (client.Connected)
                        {
                            client.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Lỗi khi đóng kết nối client: {ex.Message}",
                            "Server Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }

                // Xóa các client đã ngắt kết nối khỏi danh sách
                foreach (var client in disconnectedClients)
                {
                    clients.Remove(client);
                }

                // Dừng listener
                listener.Stop();

                textBox_Editor.AppendText("Server closed.");
            }
        }

        private async void Bai_04_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isListening)
            {
                // Gửi thông báo đến tất cả client rằng server sẽ đóng
                string shutdownMessage = "Server đang đóng. Vui lòng thoát khỏi phòng chat.\r\n";
                byte[] messageBuffer = Encoding.UTF8.GetBytes(shutdownMessage);
                isListening = false;

                List<TcpClient> disconnectedClients = new List<TcpClient>();

                foreach (var client in clients)
                {
                    try
                    {
                        // Kiểm tra xem client có còn kết nối không
                        if (client.Connected)
                        {
                            // Gửi thông báo đến client
                            await client.GetStream().WriteAsync(messageBuffer, 0, messageBuffer.Length);
                        }
                        else
                        {
                            disconnectedClients.Add(client);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Lỗi khi gửi thông báo đến client: {ex.Message}",
                            "Server Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        disconnectedClients.Add(client); // Thêm client vào danh sách ngắt kết nối
                    }
                }

                // Đợi 5 giây để đảm bảo tất cả client nhận được thông báo
                await Task.Delay(5000);

                // Đóng tất cả các kết nối client
                foreach (var client in clients)
                {
                    try
                    {
                        if (client.Connected)
                        {
                            client.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Lỗi khi đóng kết nối client: {ex.Message}",
                            "Server Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }

                // Xóa các client đã ngắt kết nối khỏi danh sách
                foreach (var client in disconnectedClients)
                {
                    clients.Remove(client);
                }

                // Dừng listener
                listener.Stop();

                textBox_Editor.AppendText("Server closed.");
            }
        }
    }

}
