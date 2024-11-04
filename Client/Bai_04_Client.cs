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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Bai_04_Client : Form
    {
        public Bai_04_Client()
        {
            InitializeComponent();
        }

        private TcpClient tcpClient;
        private NetworkStream stream;
        private bool isConnected = false;


        private async void button_Connect_Click(object sender, EventArgs e)
        {
            // Yêu cầu người dùng phải nhập tên trước khi join vào roomchat
            if (string.IsNullOrEmpty(textBox_Name.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên của bạn",
                    "Client Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync("127.0.0.1", 8080);
                stream = tcpClient.GetStream();
                isConnected = true;

                // Nhận nội dung hiện tại từ server
                _ = Task.Run(() => ReceiveContentAsync());
            }

        }

        private async Task ReceiveContentAsync()
        {
            byte[] buffer = new byte[1024];
            int byteCount;

            while (isConnected && (byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string content = Encoding.UTF8.GetString(buffer, 0, byteCount);
                textBox_Chat.Invoke((MethodInvoker)(() =>
                {
                    textBox_Chat.Text = content;
                }));
            }
        }

        private async void button_Send_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show(
                    "Bạn chưa tham gia phòng chat", 
                    "Client Warning", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
            } 
            else
            {
                if (string.IsNullOrEmpty(textBox_Message.Text))
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
                    string message = $"{textBox_Name.Text}: " + textBox_Message.Text + "\r\n";
                    textBox_Chat.AppendText(message);
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                    textBox_Message.Clear();
                }
            }
        }

        private async void button_Disconnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                // Gửi thông báo đến server là đã ra khỏi phòng Chat
                string message = $"{textBox_Name.Text} đã rời khỏi phòng chat";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                isConnected = false;
                stream.Close();
                tcpClient.Close();
                textBox_Chat.Clear();
            }
        }

    }

}

