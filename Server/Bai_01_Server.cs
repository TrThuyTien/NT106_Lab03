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
    public partial class Bai_01_Server : Form
    {
        public Bai_01_Server()
        {
            InitializeComponent();
        }

        bool isListening;
        UdpClient server;

        private async void button_Listen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Port.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập số Port",
                    "Cảnh báo: Chưa nhập số Port",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                int port = Convert.ToInt32(textBox_Port.Text);
                if (port < 0 || port >= Math.Pow(2, 16))
                {
                    MessageBox.Show(
                        "Bạn đã nhập ngoài phạm vi của Port\nPhạm vi của Port: 0 - 65565\nVui lòng nhập số Port trong phạm vi 1024 - 49515",
                        "Cảnh báo: Số port không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else if (port >= 0 && port < 1024)
                {
                    MessageBox.Show(
                        "Vui lòng nhập số Port trong phạm vi 1024 - 49515",
                        "Cảnh báo: Số port không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    try
                    {
                        server = new UdpClient(port);
                        isListening = true;
                        await Task.Run(() =>
                        {
                            while (isListening)
                            {
                                try
                                {
                                    IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 0);
                                    Byte[] data = server.Receive(ref ipEnd);
                                    string message = Encoding.UTF8.GetString(data);
                                    richTextBox_ReceiveMessage.Invoke((MethodInvoker)(() =>
                                    {
                                        richTextBox_ReceiveMessage.Text += ipEnd.Address.ToString() + ": "
                                            + message + Environment.NewLine;
                                    }));
                                }
                                catch (SocketException)
                                {
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex.Message, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error: " + ex.Message,
                            "UDP Server Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                richTextBox_ReceiveMessage.Text = "";
                isListening = false; // Ngừng vòng lặp lắng nghe
                server.Close(); // Đóng socket
                MessageBox.Show(
                    "Đã dừng lắng nghe và đóng kết nối.",
                    "Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Port.Text = "";
            richTextBox_ReceiveMessage.Text = "";
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ClearReceiveMessages_Click(object sender, EventArgs e)
        {
            richTextBox_ReceiveMessage.Text = "";
        }
    }
}
