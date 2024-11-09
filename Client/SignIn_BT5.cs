using System;
using System.Windows.Forms;

namespace Client
{
    public partial class SignIn_BT5 : Form
    {
        // Sử dụng Dictionary từ SignUp_BT5 để kiểm tra thông tin đăng nhập
        private static Dictionary<string, string> users = SignUp_BT5.users;

        // Biến static để lưu tên người dùng khi đăng nhập
        public static string CurrentUsername { get; set; }

        public SignIn_BT5()
        {
            InitializeComponent();
            SignUp_BT5.LoadUsersFromFile();

        }

        // Chuyển sang form đăng ký khi người dùng click vào liên kết "Sign Up"
        private void label_SwitchSignUp_Click_1(object sender, EventArgs e)
        {
            SignUp_BT5 form = new SignUp_BT5();
            this.Hide();
            form.ShowDialog();
        }

        // Hiển thị mật khẩu khi click vào nút
        private void button_ShowPass_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.UseSystemPasswordChar)
            {
                textBox_Pass.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_Pass.UseSystemPasswordChar = true;
            }
        }

        // Kiểm tra thông tin đăng nhập và lưu tên người dùng vào CurrentUsername nếu đăng nhập thành công
        private void button_SignIn_Click(object sender, EventArgs e)
        {
            string username = textBox_User.Text.Trim();
            string password = textBox_Pass.Text.Trim();

            // Kiểm tra tên người dùng và mật khẩu có hợp lệ không
            if (users.ContainsKey(username) && users[username] == password)
            {
                // Lưu tên người dùng vào biến static
                CurrentUsername = username;

                MessageBox.Show("Login successful!");

                // Ẩn form đăng nhập và mở form client
                this.Hide();
                Bai_05_Client client = new Bai_05_Client();
                client.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect username or password!");
            }
        }
    }
}
