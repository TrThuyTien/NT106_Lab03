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
    public partial class Bai_02_Server : Form
    {
        public Bai_02_Server()
        {
            InitializeComponent();
        }

        TcpListener server;
        TcpClient client;
        bool isListening = false;
        NetworkStream stream;
        private async void button_Listen_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                MessageBox.Show(
                    "Server đang lắng nghe",
                    "Server Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                ;
            }
            else
            {
                isListening = true;
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                server.Start();
                richTextBox_Content.AppendText("Server is listening...\r\n");
                while (isListening)
                {
                    try
                    {
                        client = await server.AcceptTcpClientAsync();
                        stream = client.GetStream();
                        await receiveMessageFromTelnet();
                    }
                    catch (Exception ex) { 
                    }

                }
            }
        }

        private async Task receiveMessageFromTelnet()
        {
            richTextBox_Content.AppendText("Client connected: " + client.Client.RemoteEndPoint.ToString() + "\r\n");
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            try
            {
                while (isListening && (bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    richTextBox_Content.AppendText(message);
                }
            }
            catch (IOException ex)
            {
                richTextBox_Content.AppendText($"Error: {ex.Message}\r\n");
            }
        }
    }
}
