using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Bai_01 : Form
    {
        public Bai_01()
        {
            InitializeComponent();
        }

        private async void button_Send_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                IPAddress ipAdd;
                bool checkIP = IPAddress.TryParse(textBox_IPRemote.Text, out ipAdd); 
                int port = Convert.ToInt32(textBox_Port.Text);
                if (port >= 0 && port <= 1023)
                {
                    MessageBox.Show("Đây là các Port chuẩn dành cho mạng\nVui lòng nhập ngoài khoảng này.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (port < 0 || port > 65535)
                {
                    MessageBox.Show("Bạn đã nhập ngoài phạm vi của port\nPhạm vi của port hợp lệ là 0 - 65535\nVui lòng nhập ngoài khoảng này.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Tạo EndPoint và gửi message
                IPEndPoint endPoint = new IPEndPoint(ipAdd, port);
                Byte[] sendBytes = Encoding.UTF8.GetBytes(richTextBox_Message.Text);
                udpClient.Send(sendBytes, sendBytes.Length, endPoint);

            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString, "Lỗi", MessageBoxButtons.OK, M)
            }
        }
    }
}
