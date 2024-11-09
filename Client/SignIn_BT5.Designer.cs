namespace Client
{
    partial class SignIn_BT5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_SignUp = new Label();
            textBox_Pass = new TextBox();
            textBox_User = new TextBox();
            label_Pass = new Label();
            label_UserName = new Label();
            label_SwitchSignUp = new Label();
            label1 = new Label();
            button_SignIn = new Button();
            button_ShowPass = new Button();
            SuspendLayout();
            // 
            // label_SignUp
            // 
            label_SignUp.AutoSize = true;
            label_SignUp.Font = new Font("Sitka Small", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_SignUp.ForeColor = Color.Transparent;
            label_SignUp.Location = new Point(300, 9);
            label_SignUp.Name = "label_SignUp";
            label_SignUp.Size = new Size(137, 42);
            label_SignUp.TabIndex = 1;
            label_SignUp.Text = "SIGN IN";
            // 
            // textBox_Pass
            // 
            textBox_Pass.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_Pass.Location = new Point(42, 246);
            textBox_Pass.Name = "textBox_Pass";
            textBox_Pass.Size = new Size(648, 31);
            textBox_Pass.TabIndex = 9;
            textBox_Pass.UseSystemPasswordChar = true;
            // 
            // textBox_User
            // 
            textBox_User.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_User.Location = new Point(42, 126);
            textBox_User.Name = "textBox_User";
            textBox_User.Size = new Size(648, 31);
            textBox_User.TabIndex = 8;
            // 
            // label_Pass
            // 
            label_Pass.AutoSize = true;
            label_Pass.Font = new Font("Sitka Small", 12F);
            label_Pass.ForeColor = Color.Transparent;
            label_Pass.Location = new Point(38, 191);
            label_Pass.Name = "label_Pass";
            label_Pass.Size = new Size(110, 29);
            label_Pass.TabIndex = 7;
            label_Pass.Text = "Password";
            // 
            // label_UserName
            // 
            label_UserName.AutoSize = true;
            label_UserName.Font = new Font("Sitka Small", 12F);
            label_UserName.ForeColor = Color.Transparent;
            label_UserName.Location = new Point(38, 74);
            label_UserName.Name = "label_UserName";
            label_UserName.Size = new Size(115, 29);
            label_UserName.TabIndex = 6;
            label_UserName.Text = "Username";
            // 
            // label_SwitchSignUp
            // 
            label_SwitchSignUp.AutoSize = true;
            label_SwitchSignUp.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_SwitchSignUp.ForeColor = Color.MediumBlue;
            label_SwitchSignUp.Location = new Point(601, 402);
            label_SwitchSignUp.Name = "label_SwitchSignUp";
            label_SwitchSignUp.Size = new Size(95, 29);
            label_SwitchSignUp.TabIndex = 12;
            label_SwitchSignUp.Text = "Sign Up";
            label_SwitchSignUp.Click += label_SwitchSignUp_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(350, 402);
            label1.Name = "label1";
            label1.Size = new Size(245, 29);
            label1.TabIndex = 11;
            label1.Text = "Don't have an account?";
            // 
            // button_SignIn
            // 
            button_SignIn.AutoSize = true;
            button_SignIn.BackColor = SystemColors.ButtonHighlight;
            button_SignIn.FlatStyle = FlatStyle.Flat;
            button_SignIn.Font = new Font("Sitka Small", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_SignIn.Location = new Point(300, 327);
            button_SignIn.Name = "button_SignIn";
            button_SignIn.Size = new Size(155, 47);
            button_SignIn.TabIndex = 10;
            button_SignIn.Text = "Sign In";
            button_SignIn.UseVisualStyleBackColor = false;
            button_SignIn.Click += button_SignIn_Click;
            // 
            // button_ShowPass
            // 
            button_ShowPass.AutoSize = true;
            button_ShowPass.BackColor = Color.Transparent;
            button_ShowPass.BackgroundImage = Properties.Resources.Thiết_kế_chưa_có_tên;
            button_ShowPass.BackgroundImageLayout = ImageLayout.Zoom;
            button_ShowPass.FlatAppearance.BorderSize = 0;
            button_ShowPass.FlatStyle = FlatStyle.Flat;
            button_ShowPass.Location = new Point(696, 242);
            button_ShowPass.Name = "button_ShowPass";
            button_ShowPass.Size = new Size(40, 40);
            button_ShowPass.TabIndex = 13;
            button_ShowPass.UseVisualStyleBackColor = false;
            button_ShowPass.Click += button_ShowPass_Click;
            // 
            // SignIn_BT5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrange;
            ClientSize = new Size(758, 462);
            Controls.Add(button_ShowPass);
            Controls.Add(label_SwitchSignUp);
            Controls.Add(label1);
            Controls.Add(button_SignIn);
            Controls.Add(textBox_Pass);
            Controls.Add(textBox_User);
            Controls.Add(label_Pass);
            Controls.Add(label_UserName);
            Controls.Add(label_SignUp);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignIn_BT5";
            Text = "SIGN IN";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label_SignUp;
        private TextBox textBox_Pass;
        private TextBox textBox_User;
        private Label label_Pass;
        private Label label_UserName;
        private Label label_SwitchSignUp;
        private Label label1;
        private Button button_SignIn;
        private Button button_ShowPass;

        #endregion
    }
}