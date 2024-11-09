using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    public partial class SignUp_BT5 : Form
    {
        // Tạo một Dictionary để lưu trữ thông tin người dùng (username, password)
        public static Dictionary<string, string> users = new Dictionary<string, string>();
        public const string filePath = "users.txt";  // Tên tệp để lưu trữ người dùng

        public SignUp_BT5()
        {
            InitializeComponent();
            LoadUsersFromFile();  // Đọc dữ liệu từ tệp khi ứng dụng khởi động
        }

        private void label_SwitchSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn_BT5 form = new SignIn_BT5();
            form.ShowDialog();
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.UseSystemPasswordChar)
            {
                textBox_Pass.UseSystemPasswordChar = false;
                textBox_cfPass.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_Pass.UseSystemPasswordChar = true;
                textBox_cfPass.UseSystemPasswordChar = true;
            }
        }

        private void button_SignUp_Click(object sender, EventArgs e)
        {
            string username = textBox_User.Text.Trim();
            string password = textBox_Pass.Text.Trim();
            string confirmPassword = textBox_cfPass.Text.Trim();

            // Kiểm tra xem mật khẩu và xác nhận mật khẩu có khớp không
            if (password != confirmPassword)
            {
                MessageBox.Show("Password entered is incorrect!");
                return;
            }

            // Kiểm tra xem tên người dùng đã tồn tại trong Dictionary chưa
            if (users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            // Nếu tên người dùng chưa tồn tại, thêm tài khoản mới vào Dictionary
            users.Add(username, password);
            SaveUserToFile(username, password);  // Lưu người dùng vào tệp

            MessageBox.Show("Registration successful!");
            this.Hide();
            new Bai_05_Client().ShowDialog();
        }

        private void SaveUserToFile(string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{username},{password}");  // Lưu tên người dùng và mật khẩu vào tệp
            }

            if (File.Exists(filePath))
            {
                Console.WriteLine("File users.txt tồn tại và đã được ghi dữ liệu.");
            }
            else
            {
                MessageBox.Show("Không thể tìm thấy file users.txt sau khi đăng ký.");
            }
        }

        public static void LoadUsersFromFile()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        users[parts[0]] = parts[1];  // Tạo lại Dictionary từ tệp
                    }
                }
            }
        }
    }
}
