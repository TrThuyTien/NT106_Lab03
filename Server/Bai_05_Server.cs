using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Bai_05_Server : Form
    {
        public Bai_05_Server()
        {
            InitializeComponent();
        }

        TcpListener tcpListener;
        private static Dictionary<string, List<TcpClient>> chatRooms = new Dictionary<string, List<TcpClient>>(); // Lưu trữ client theo phòng chat
        private static int portCount = 8080; // Cổng bắt đầu
        private static string chats = ""; // Nội dung đoạn chat chung
        private bool isListening = false;

        private async void button_Listen_Click(object sender, EventArgs e)
        {
            button_Listen.Enabled = false;
            button_Stop.Enabled = true;
            // Tạo cổng và endpoint cho server
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), portCount++);
            tcpListener = new TcpListener(endPoint);
            tcpListener.Start();

            richTextBox_Messages.AppendText($"Server is running on {endPoint.Address}: {endPoint.Port}\n");
            isListening = true;

            try
            {
                while (isListening)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    NetworkStream stream = client.GetStream();

                    // Đọc roomID từ client (client phải gửi roomID khi kết nối)
                    byte[] roomIDBuffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(roomIDBuffer, 0, roomIDBuffer.Length);
                    string roomID = Encoding.UTF8.GetString(roomIDBuffer, 0, bytesRead);

                    if (roomID.StartsWith("CreateRoom "))
                    {
                        string requestedRoomID = roomID.Split(' ')[1].Trim(); // Tách RoomID từ thông điệp
                        richTextBox_Messages.AppendText($"Client from {endPoint.Address}: {endPoint.Port} want to create new room {requestedRoomID}!\n");

                        if (chatRooms.ContainsKey(requestedRoomID)) // Kiểm tra nếu phòng đã tồn tại trong danh sách phòng hiện tại
                        {
                            await SendResponseAsync("N", stream);  // Nếu phòng đã tồn tại
                            richTextBox_Messages.AppendText($"Client from {clientEndPoint.Address}:{clientEndPoint.Port} failed to create room {requestedRoomID}!\n");
                        }
                        else // Nếu phòng chưa tồn tại, tạo phòng và phản hồi "Y"
                        {
                            lock (chatRooms)
                            {
                                chatRooms[requestedRoomID] = new List<TcpClient>(); // Tạo phòng mới và thêm vào danh sách chatRooms
                            }

                            await SendResponseAsync("Y", stream); // Phản hồi "Y" để xác nhận tạo phòng thành công

                            richTextBox_Messages.AppendText($"Client from {clientEndPoint.Address}:{clientEndPoint.Port} create {requestedRoomID}!\n");

                            string successMessage = $"Room {requestedRoomID} has been created successfully!";
                            byte[] successResponse = Encoding.UTF8.GetBytes(successMessage);
                            await stream.WriteAsync(successResponse, 0, successResponse.Length);

                            _ = Task.Run(() => HandleClientAsync(client, requestedRoomID));

                        }
                    }
                    else if (roomID.StartsWith("Joinroom "))
                    {
                        string requestedRoomID = roomID.Split(' ')[1].Trim(); // Tách RoomID từ thông điệp
                        if (chatRooms.ContainsKey(requestedRoomID)) // Kiểm tra nếu phòng đã tồn tại trong danh sách phòng hiện tại
                        {
                            await SendResponseAsync("Y", stream);  // Nếu phòng đã tồn tại
                            richTextBox_Messages.AppendText($"Client from {clientEndPoint.Address}:{clientEndPoint.Port} joined room {requestedRoomID}!\n");

                            byte[] welcomeMessage = Encoding.UTF8.GetBytes($"Join in: {requestedRoomID}");
                            await stream.WriteAsync(welcomeMessage, 0, welcomeMessage.Length);

                            _ = Task.Run(() => HandleClientAsync(client, requestedRoomID));

                        }
                        else
                        {
                            await SendResponseAsync("N", stream); // Phản hồi nếu phòng không tồn tại
                        }

                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Server listening has been canceled!\n");
            }
            finally
            {
                Console.WriteLine("Server stopped!\n");
            }
        }

        // Dictionary lưu các tin nhắn cho từng phòng chat
        private Dictionary<string, List<string>> chatRoomMessages = new Dictionary<string, List<string>>();

        private async Task HandleClientAsync(TcpClient tcpClient, string roomID)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                // Kiểm tra và gửi lại lịch sử tin nhắn cho client mới
                if (chatRoomMessages.ContainsKey(roomID))
                {
                    foreach (string previousMessage in chatRoomMessages[roomID])
                    {
                        byte[] messageData = Encoding.UTF8.GetBytes(previousMessage);
                        await stream.WriteAsync(messageData, 0, messageData.Length);
                    }
                }
                else
                {
                    // Nếu phòng chưa có tin nhắn nào, tạo danh sách trống cho room đó
                    lock (chatRoomMessages)
                    {
                        chatRoomMessages[roomID] = new List<string>();
                    }
                }

                // Thêm client vào danh sách phòng chat
                lock (chatRooms)
                {
                    chatRooms[roomID].Add(tcpClient);
                }

                while (true) // Lặp lại để xử lý các tin nhắn của client
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Nếu không còn dữ liệu thì kết thúc

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string chatMessage = $"[{roomID}] {message}\n";

                    // Lưu tin nhắn vào lịch sử phòng chat
                    lock (chatRoomMessages)
                    {
                        chatRoomMessages[roomID].Add(chatMessage);
                    }

                    // Hiển thị tin nhắn trong richTextBox
                    richTextBox_Messages.Invoke((MethodInvoker)(() => richTextBox_Messages.AppendText(chatMessage)));

                    // Phát tán tin nhắn tới các client khác trong phòng
                    await BroadcastUpdateAsync(chatMessage, tcpClient, roomID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing client: " + ex.Message);
            }
            finally
            {
                // Xóa client khỏi phòng chat và đóng kết nối
                lock (chatRooms)
                {
                    chatRooms[roomID].Remove(tcpClient);
                }
                tcpClient.Close();
            }
        }

        // Hàm gửi phản hồi cho client
        private async Task SendResponseAsync(string responseMessage, NetworkStream stream)
        {
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseMessage);
            await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }

        private static async Task BroadcastUpdateAsync(string update, TcpClient sender, string roomID)
        {
            byte[] updateBuffer = Encoding.UTF8.GetBytes(update);
            List<TcpClient> clientsCopy;

            lock (chatRooms)
            {
                // Lấy danh sách client của phòng chat
                clientsCopy = new List<TcpClient>(chatRooms[roomID]);
            }

            List<Task> tasks = new List<Task>();
            foreach (TcpClient client in clientsCopy)
            {
                if (client != sender)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        Task sendTask = stream.WriteAsync(updateBuffer, 0, updateBuffer.Length);
                        tasks.Add(sendTask);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending message to {client.Client.RemoteEndPoint}: {ex.Message}");
                    }
                }
            }
            await Task.WhenAll(tasks); // Đợi tất cả các tác vụ gửi tin nhắn hoàn tất
        }

        private async void button_Stop_Click(object sender, EventArgs e)
        {
            isListening = false;

            tcpListener?.Stop();

            lock (chatRooms)
            {
                foreach (var room in chatRooms.Values)
                {
                    foreach (var tcpclient in room)
                    {
                        try
                        {
                            tcpclient.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error closing client connection: {ex.Message}");
                        }
                    }
                }
                chatRooms.Clear();
            }

            richTextBox_Messages.AppendText("Server stopped!\n");
            button_Stop.Enabled = false;
            button_Listen.Enabled = true;
        }
    }
}
