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
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("127.0.0.1", 8080);
            stream = tcpClient.GetStream();
            isConnected = true;

            // Nhận nội dung hiện tại từ server
            _ = Task.Run(() => ReceiveContentAsync());
            textBox_Editor.Enabled = true;
        }

        private async Task ReceiveContentAsync()
        {
            byte[] buffer = new byte[1024];
            int byteCount;

            while (isConnected && (byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string content = Encoding.UTF8.GetString(buffer, 0, byteCount);
                textBox_Editor.Invoke((MethodInvoker)(() =>
                {
                    textBox_Editor.Text = content;
                }));
            }
        }

        private async void textBox_Editor_TextChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                string updatedContent = textBox_Editor.Text;
                byte[] bufferContent = Encoding.UTF8.GetBytes(updatedContent);
                await stream.WriteAsync(bufferContent, 0, bufferContent.Length);
            }
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                isConnected = false;
                stream.Close();
                tcpClient.Close();
                textBox_Editor.Enabled = false;
                textBox_Editor.Clear();
            }
        }
    }

}

