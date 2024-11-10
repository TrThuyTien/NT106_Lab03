using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
        CancellationTokenSource cancellationTokenSource;
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
                cancellationTokenSource = new CancellationTokenSource();
                // Lấy địa chỉ IP cụ thể của máy tính
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                server.Start();
                IPEndPoint localEndPoint = (IPEndPoint)server.LocalEndpoint;
                string ipAddress = localEndPoint.Address.ToString();
                int port = localEndPoint.Port;
                richTextBox_Content.AppendText($"Telnet running on {ipAddress}:{port}\r\n"); 
                while (isListening)
                {
                    try
                    {
                        client = await server.AcceptTcpClientAsync();
                        if (client != null)
                        {
                            stream = client.GetStream();
                            await receiveMessageFromTelnet();
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        richTextBox_Content.AppendText("Server đã dừng.\r\n");
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối: " + ex.ToString(), "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
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
                while (isListening)
                {
                    // Kiểm tra xem kết nối có còn mở không
                    if (client.Client.Poll(1000, SelectMode.SelectRead) && client.Client.Available == 0)
                    {
                        // Kết nối đã bị đóng
                        break;
                    }

                    
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // Kết nối đã bị đóng
                        break;
                    }

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    richTextBox_Content.AppendText(message);
                }
            }
            catch (IOException ex)
            {
                richTextBox_Content.AppendText($"Error: {ex.Message}\r\n");
            }
            catch (Exception ex)
            {
                richTextBox_Content.AppendText($"Unexpected Error: {ex.Message}\r\n");
            }
            finally
            {
                // Đảm bảo đóng kết nối khi hoàn thành
                closeConnection();
            }
        }

        private void closeConnection()
        {
            // Đóng stream nếu nó không null
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }

            // Đóng client nếu nó không null
            if (client != null)
            {
                client.Close();
                client = null;
            }

            // Dừng server nếu nó đang chạy
            if (server != null)
            {
                server.Stop();
                server = null;
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                isListening = false;
                try
                {
                    cancellationTokenSource.Cancel();
                    closeConnection();
                    richTextBox_Content.AppendText("Server đóng kết nối.\r\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi khi đóng kết nối: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
