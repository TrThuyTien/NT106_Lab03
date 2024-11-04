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
                    clients.Add(client);
                    textBox_Editor.AppendText($"New client connected from: {clientEndPoint.Address}: {clientEndPoint.Port}\r\n");
                }
                _ = Task.Run(() => HandleClientAsync(client));
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
                    contentChat += message + Environment.NewLine;

                    IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    textBox_Editor.AppendText($"{clientEndPoint.Address}:{clientEndPoint.Port}: " + message);
                    // Broadcast tin nhắn đến các client khác
                    await BroadcastUpdateAsync(contentChat, client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xử lý client: " + ex.Message);
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

    }

}
