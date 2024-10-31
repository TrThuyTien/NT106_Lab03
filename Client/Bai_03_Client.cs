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

namespace Client
{
    public partial class Bai_03_Client : Form
    {
        public Bai_03_Client()
        {
            InitializeComponent();
        }

        private TcpClient client;
        private NetworkStream stream;
        private bool isConnecting = false;
        private CancellationTokenSource cancellationTokenSource;

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            if (!isConnecting)
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
                    "Client Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void button_ClearChat_Click(object sender, EventArgs e)
        {
            richTextBox_Chat.Text = "";
        }

        private async void button_Connect_Click(object sender, EventArgs e)
        {
            if (!isValidIPAddress(textBox_IPAddress.Text))
            {
                MessageBox.Show(
                    "Địa chỉ IP không hợp lệ",
                    "Client Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else if (!isValidPort(textBox_Port.Text))
            {
                MessageBox.Show(
                    "Số port không hợp lệ\nVui lòng nhập trong khoảng 1024 - 65535",
                    "Client Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                isConnecting = true;
                await ConnectToServerAsync();
            }
        }

        private async Task ConnectToServerAsync()
        {
            IPAddress ipAdd = IPAddress.Parse(textBox_IPAddress.Text);
            int port = Convert.ToInt32(textBox_Port.Text);
            IPEndPoint ipEnd = new IPEndPoint(ipAdd, port);
            client = new TcpClient();
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await client.ConnectAsync(ipEnd);
                richTextBox_Chat.AppendText("Connected to server\r\n");
                stream = client.GetStream();

                await Task.Run(() => receiveMessageAsync());
            }
            catch (Exception ex)
            {
                richTextBox_Chat.AppendText("Could not connect to server: " + ex.Message + "\n");
                isConnecting = false;
            }
        }


        private async Task receiveMessageAsync()
        {
            while (isConnecting)
            {
                byte[] buffer = new byte[1024];
                int byteCount = 0;
                try
                {
                    while ((byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                        richTextBox_Chat.Invoke((MethodInvoker)(() =>
                        {
                            richTextBox_Chat.AppendText("Server: " + message + Environment.NewLine);
                        }));
                    }
                }
                catch (IOException ex)
                {
                    richTextBox_Chat.Invoke((MethodInvoker)(() =>
                    {
                        richTextBox_Chat.AppendText("Disconnected. Attempting to reconnect...\r\n");
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
        }

        private async void button_Send_Click(object sender, EventArgs e)
        {
            if (isEmptyMessage(richTextBox_Message.Text))
            {
                MessageBox.Show(
                   "Vui lòng nhập Message",
                   "Client Warning",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            else
            {
                if (stream != null && stream.CanWrite)
                {
                    string message = richTextBox_Message.Text;
                    byte[] data = Encoding.UTF8.GetBytes("0:" + message);
                    await stream.WriteAsync(data, 0, data.Length);
                    richTextBox_Chat.AppendText("Client: " + message + "\r\n");
                    richTextBox_Message.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể gửi message bởi vì chưa kết nối với Server.",
                        "Client Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (isConnecting)
            {
                richTextBox_Chat.AppendText("Client disconnected.\n");
                isConnecting = false;
                cancellationTokenSource?.Cancel();
                if (stream != null)
                {
                    // Gửi thông báo ngắt kết nối
                    string disconnectMessage = "1:Client is closing the connection";
                    byte[] data = Encoding.UTF8.GetBytes(disconnectMessage);
                    stream.Write(data, 0, data.Length);

                    stream.Close();
                    stream = null;
                }
                if (client != null)
                {
                    client.Close();
                    client = null;
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
