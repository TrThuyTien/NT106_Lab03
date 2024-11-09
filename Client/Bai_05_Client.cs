using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Bai_05_Client : Form
    {
        public Bai_05_Client()
        {
            InitializeComponent();
        }
        private TcpClient tcpClient;
        private NetworkStream stream;
        private bool isConnected = false;
        private async void button_Connect_Click(object sender, EventArgs e)
        {
            string username = SignIn_BT5.CurrentUsername;
            string roomID = textBox_RoomID.Text;

            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("127.0.0.1", 8080); // Kết nối đến server
            stream = tcpClient.GetStream();
            isConnected = true;

            if (string.IsNullOrEmpty(roomID))
            {
                MessageBox.Show("Please enter room number!", "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (comboBox_Room.SelectedIndex == 0)
                {
                    byte[] RequestCreate = Encoding.UTF8.GetBytes($"CreateRoom {roomID}");
                    await stream.WriteAsync(RequestCreate, 0, RequestCreate.Length);

                    byte[] responseBuffer = new byte[1024];
                    int responseBytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                    string serverResponse = Encoding.UTF8.GetString(responseBuffer, 0, responseBytesRead).Trim();

                    if (serverResponse != "Y")
                    {
                        richTextBox_Chat.AppendText($"Room {roomID} already exists! Please enter another room ID!");
                    }
                    else
                    {
                        richTextBox_Chat.Clear();
                        _ = Task.Run(() => ReceiveContentAsync(stream));

                    }
                }
                else
                {
                    byte[] RequestCreate = Encoding.UTF8.GetBytes($"Joinroom {roomID}");
                    await stream.WriteAsync(RequestCreate, 0, RequestCreate.Length);

                    byte[] responseBuffer = new byte[1024];
                    int responseBytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                    string serverResponse = Encoding.UTF8.GetString(responseBuffer, 0, responseBytesRead).Trim();

                    if (serverResponse != "Y")
                    {
                        richTextBox_Chat.AppendText($"Room {roomID} does not exist! Please enter another room ID!\n");
                    }
                    else
                    {
                        richTextBox_Chat.Clear();
                        _ = Task.Run(() => ReceiveContentAsync(stream));

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:: {ex}");
            }
        }
        private async Task ReceiveContentAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int byteCount;

            // Khi kết nối vẫn còn hoạt động
            while (isConnected && (byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                // Đọc và giải mã nội dung tin nhắn từ server
                string content = Encoding.UTF8.GetString(buffer, 0, byteCount);

                // Cập nhật RichTextBox để hiển thị tin nhắn
                richTextBox_Chat.Invoke((MethodInvoker)(() =>
                {
                    richTextBox_Chat.AppendText(content + "\n");  // Hiển thị tin nhắn trong RichTextBox
                }));
            }
        }
        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button_Send_Click(object sender, EventArgs e)
        {
            string username = SignIn_BT5.CurrentUsername;

            // Kiểm tra nếu chưa tham gia phòng chat
            if (!isConnected)
            {
                MessageBox.Show(
                    "You have not joined the chat room",
                    "Client Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // Thoát khỏi hàm nếu chưa kết nối
            }

            // Kiểm tra nếu không có tin nhắn để gửi
            if (string.IsNullOrEmpty(richTextBox_Message.Text))
            {
                MessageBox.Show("Please enter message", "Client Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi hàm nếu không có tin nhắn
            }

            // Tạo tin nhắn từ người dùng
            string message = $"{username}: " + richTextBox_Message.Text + "\n";
            richTextBox_Chat.AppendText(message);

            // Kiểm tra nếu stream chưa được khởi tạo
            if (stream == null)
            {
                MessageBox.Show("Error: No connection to server.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng gửi nếu stream không hợp lệ
            }

            try
            {
                // Gửi tin nhắn qua stream
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                richTextBox_Message.Clear(); // Xóa tin nhắn đã nhập sau khi gửi
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}