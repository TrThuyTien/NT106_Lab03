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
    public partial class Bai_04_Server : Form
    {
        public Bai_04_Server()
        {
            InitializeComponent();
        }

        TcpListener listener;
        private static List<TcpClient> clients = new List<TcpClient>();
        private static string sharedContent = ""; // Nội dung văn bản chung
        private static readonly object lockObject = new object();
        private static DateTime lastUpdateTime = DateTime.MinValue;
        private static readonly TimeSpan debounceTime = TimeSpan.FromMilliseconds(200); // Thời gian debounce

        private async void button_Listen_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
            textBox_Editor.Text = "Server đang chạy trên cổng 8080...";
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                lock (clients)
                {
                    clients.Add(client);
                }
                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            // Gửi nội dung hiện tại tới client mới
            byte[] contentBuffer = Encoding.UTF8.GetBytes(sharedContent);
            await stream.WriteAsync(contentBuffer, 0, contentBuffer.Length);

            // Nhận các cập nhật từ client
            byte[] buffer = new byte[1024];
            int byteCount;
            while ((byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string update = Encoding.UTF8.GetString(buffer, 0, byteCount);
                await ProcessUpdateAsync(update, client);
            }

            // Ngắt kết nối client
            lock (clients)
            {
                clients.Remove(client);
            }
        }

        private async Task ProcessUpdateAsync(string update, TcpClient sender)
        {
            lock (lockObject)
            {
                // Kiểm tra thời gian cập nhật
                if (DateTime.Now - lastUpdateTime < debounceTime)
                {
                    return; // Bỏ qua cập nhật nếu chưa đủ thời gian debounce
                }

                sharedContent = update; // Cập nhật nội dung chung
                lastUpdateTime = DateTime.Now; // Cập nhật thời gian
                textBox_Editor.Text = update; // Cập nhật giao diện
            }

            await BroadcastUpdateAsync(update, sender);
        }

        private static async Task BroadcastUpdateAsync(string update, TcpClient sender)
        {
            byte[] updateBuffer = Encoding.UTF8.GetBytes(update);
            List<TcpClient> clientsCopy;

            lock (clients)
            {
                // Tạo một bản sao của danh sách clients
                clientsCopy = new List<TcpClient>(clients);
            }

            List<Task> tasks = new List<Task>();
            foreach (TcpClient client in clientsCopy)
            {
                if (client != sender)
                {
                    NetworkStream stream = client.GetStream();
                    tasks.Add(stream.WriteAsync(updateBuffer, 0, updateBuffer.Length));
                }
            }

            await Task.WhenAll(tasks);
        }

    }

}
