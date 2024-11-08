using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class Bai_01_Client : Form
    {
        public Bai_01_Client()
        {
            InitializeComponent();
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                int port;
                IPAddress ipAdd;

                // Kiểm tra và chuyển đổi Port
                if (!int.TryParse(textBox_Port.Text, out port))
                {
                    MessageBox.Show(
                        "Vui lòng nhập một số cho Port",
                        "Client Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (port >= 0 && port <= 1023)
                {
                    MessageBox.Show(
                        "Đây là các Port chuẩn dành cho mạng\nVui lòng nhập ngoài khoảng này.",
                        "Client Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                else if (port < 0 || port > 65535)
                {
                    MessageBox.Show(
                        "Bạn đã nhập ngoài phạm vi của port\nPhạm vi của port hợp lệ là 0 - 65535",
                        "Client Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                if (string.IsNullOrEmpty(textBox_IPRemote.Text) || !IsValidIPAddress(textBox_IPRemote.Text))
                {
                    MessageBox.Show(
                        "Địa chỉ IP Remote host không hợp lệ",
                        "Client Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                if (string.IsNullOrEmpty(richTextBox_Message.Text))
                {
                    MessageBox.Show(
                        "Vui lòng nhập Message",
                        "Client Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Thiết lập điểm kết nối từ IP và port
                bool checkIP = IPAddress.TryParse(textBox_IPRemote.Text, out ipAdd);
                IPEndPoint endPoint = new IPEndPoint(ipAdd, port);
                Byte[] sendBytes = Encoding.UTF8.GetBytes(richTextBox_Message.Text);
                // Gửi tin nhắn
                udpClient.Send(sendBytes, sendBytes.Length, endPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                udpClient.Close();
            }
        }

        private bool IsValidIPAddress(string ipAddress)
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


        private void button_ClearMessage_Click(object sender, EventArgs e)
        {
            richTextBox_Message.Text = "";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_IPRemote.Text = "";
            textBox_Port.Text = "";
            richTextBox_Message.Text = "";
        }
    }
}
