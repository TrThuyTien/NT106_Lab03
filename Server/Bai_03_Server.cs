using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Bai_03_Server : Form
    {
        public Bai_03_Server()
        {
            InitializeComponent();
        }

        TcpListener listener;
        TcpClient client;
        NetworkStream stream;
        bool isListening = false;
        private CancellationTokenSource cancellationTokenSource;

        private void button_ClearChat_Click(object sender, EventArgs e)
        {
            richTextBox_Chat.Text = "";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                textBox_IPAddress.Text = "";
                textBox_Port.Text = "";
                richTextBox_Chat.Text = "";
                richTextBox_Message.Text = "";
            }
            else
            {
                MessageBox.Show(
                    "Vui lòng nhấn stop để ngừng kết nối trước khi thực hiện xóa",
                    "Server Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void button_Listen_Click(object sender, EventArgs e)
        {
            if (!isValidIPAddress(textBox_IPAddress.Text))
            {
                MessageBox.Show(
                    "Địa chỉ IP không hợp lệ",
                    "Server Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else if (!isValidPort(textBox_Port.Text))
            {
                MessageBox.Show(
                    "Số port không hợp lệ\nVui lòng nhập trong khoảng 1024 - 65535",
                    "Server Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                IPAddress ipAdd = IPAddress.Parse(textBox_IPAddress.Text);
                int port = Convert.ToInt32(textBox_Port.Text);
                IPEndPoint ipEnd = new IPEndPoint(ipAdd, port);
                listener = new TcpListener(ipEnd);
                listener.Start();
                isListening = true;
                richTextBox_Chat.AppendText("Waiting for a connection ...\r\n");

                // Chấp nhận kết nối từ client
                while (isListening)
                {
                    try
                    {
                        TcpClient client = await listener.AcceptTcpClientAsync();
                        richTextBox_Chat.Invoke((MethodInvoker)(() =>
                        {
                            richTextBox_Chat.AppendText("Client connected.\r\n");
                        }));

                        // Xử lý client trong một task riêng
                        _ = Task.Run(() => HandleClientAsync(client));
                    }
                    catch (Exception ex)
                    {
                        richTextBox_Chat.Invoke((MethodInvoker)(() =>
                        {
                            richTextBox_Chat.AppendText("Error: " + ex.Message + "\r\n");
                        }));
                    }
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                // Lấy NetworkStream từ TcpClient
                stream = client.GetStream();
                await receiveMessageAsync();
            }
            finally
            {
                // Đảm bảo rằng khi client ngắt kết nối, chúng ta sẽ xử lý thích hợp
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
                if (client != null)
                {
                    client.Close();
                    client = null;
                }

                // Thông báo rằng server đã sẵn sàng lắng nghe client tiếp theo
                richTextBox_Chat.Invoke((MethodInvoker)(() =>
                {
                    richTextBox_Chat.AppendText("Server is ready to accept a new client.\r\n");
                }));
            }
        }

        private async Task receiveMessageAsync()
        {
            byte[] buffer = new byte[1024];
            int byteCount;

            try
            {
                while (isListening && (byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);

                    // Kiểm tra đầu của thông điệp
                    if (message.StartsWith("1:"))
                    {
                        // Client đã gửi thông điệp ngắt kết nối
                        richTextBox_Chat.Invoke((MethodInvoker)(() =>
                        {
                            richTextBox_Chat.AppendText("Client disconnected.\r\n");
                        }));
                        break; // Thoát khỏi vòng lặp để kết thúc xử lý client
                    }
                    else if (message.StartsWith("0:"))
                    {
                        // Thông điệp bình thường từ client
                        richTextBox_Chat.Invoke((MethodInvoker)(() =>
                        {
                            richTextBox_Chat.AppendText("Client: " + message.Substring(2) + "\r\n"); // Bỏ qua "0:"
                        }));
                    }
                }
            }
            catch (IOException ex)
            {
                richTextBox_Chat.Invoke((MethodInvoker)(() =>
                {
                    richTextBox_Chat.AppendText("Connection lost. Waiting for reconnection...\r\n");
                }));
            }
            catch (ObjectDisposedException)
            {
                richTextBox_Chat.Invoke((MethodInvoker)(() =>
                {
                    richTextBox_Chat.AppendText("The connection has already been closed.\r\n");
                }));
            }
        }

        // Gửi dữ liệu tới Client
        private async void button_Send_Click(object sender, EventArgs e)
        {
            if (isEmptyMessage(richTextBox_Message.Text))
            {
                MessageBox.Show(
                   "Vui lòng nhập Message",
                   "Server Warning",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            else
            {
                if (stream != null && stream.CanWrite)
                {
                    string message = richTextBox_Message.Text;
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    richTextBox_Chat.AppendText("Server: " + message + "\r\n");
                    richTextBox_Message.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể gửi message bởi vì chưa kết nối với Client",
                        "Server Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                richTextBox_Chat.AppendText("Server stopped listening.\n");
                isListening = false;
                cancellationTokenSource?.Cancel();
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
                if (client != null)
                {
                    client.Close();
                    client = null;
                }
                if (listener != null)
                {
                    listener.Stop();
                    listener = null;
                }
                cancellationTokenSource = null;
            }
        }

        // Kiểm tra đầu vào IP Address
        private bool isValidIPAddress(string ipAddress)
        {
            // Kiểm tra định dạng IPv4
            string ipv4Pattern = @"^(\d{1,3}\.){3}\d{1,3}$";
            if (Regex.IsMatch(ipAddress, ipv4Pattern))
            {
                // Xác nhận các số trong dải hợp lệ từ 0 đến 255
                var parts = ipAddress.Split('.');
                foreach (var part in parts)
                {
                    if (int.Parse(part) < 0 || int.Parse(part) > 255)
                        return false;
                }
                return true;
            }
            // Kiểm tra định dạng IPv6
            string ipv6Pattern = @"^([\da-fA-F]{1,4}:){7}[\da-fA-F]{1,4}$";
            if (Regex.IsMatch(ipAddress, ipv6Pattern))
            {
                return true;
            }
            return false;
        }

        // Kiểm tra đầu vào Port
        private bool isValidPort(string port)
        {
            int portNum = Convert.ToInt32(port);
            if (portNum < 1024 || portNum > 65535)
                return false;
            return true;
        }

        // Kiểm tra đầu vào Message
        private bool isEmptyMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return true;
            return false;
        }
    }
}

