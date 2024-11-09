namespace Client
{
    partial class SignUp_BT5
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

        private void InitializeComponent()
        {
            label_SignUp = new Label();
            label_UserName = new Label();
            label_Pass = new Label();
            label_cfPass = new Label();
            textBox_User = new TextBox();
            textBox_Pass = new TextBox();
            textBox_cfPass = new TextBox();
            button_SignUp = new Button();
            label1 = new Label();
            label_SwitchSignIn = new Label();
            button_ShowPass = new Button();
            button_show = new Button();
            SuspendLayout();
            // 
            // label_SignUp
            // 
            label_SignUp.AutoSize = true;
            label_SignUp.Font = new Font("Sitka Small", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_SignUp.ForeColor = Color.Transparent;
            label_SignUp.Location = new Point(207, 9);
            label_SignUp.Name = "label_SignUp";
            label_SignUp.Size = new Size(344, 42);
            label_SignUp.TabIndex = 0;
            label_SignUp.Text = "CREATE AN ACCOUNT";
            // 
            // label_UserName
            // 
            label_UserName.AutoSize = true;
            label_UserName.Font = new Font("Sitka Small", 12F);
            label_UserName.ForeColor = Color.Transparent;
            label_UserName.Location = new Point(43, 79);
            label_UserName.Name = "label_UserName";
            label_UserName.Size = new Size(115, 29);
            label_UserName.TabIndex = 1;
            label_UserName.Text = "Username";
            // 
            // label_Pass
            // 
            label_Pass.AutoSize = true;
            label_Pass.Font = new Font("Sitka Small", 12F);
            label_Pass.ForeColor = Color.Transparent;
            label_Pass.Location = new Point(43, 196);
            label_Pass.Name = "label_Pass";
            label_Pass.Size = new Size(110, 29);
            label_Pass.TabIndex = 2;
            label_Pass.Text = "Password";
            // 
            // label_cfPass
            // 
            label_cfPass.AutoSize = true;
            label_cfPass.Font = new Font("Sitka Small", 12F);
            label_cfPass.ForeColor = Color.Transparent;
            label_cfPass.Location = new Point(43, 311);
            label_cfPass.Name = "label_cfPass";
            label_cfPass.Size = new Size(199, 29);
            label_cfPass.TabIndex = 3;
            label_cfPass.Text = "Confirm Password";
            // 
            // textBox_User
            // 
            textBox_User.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_User.Location = new Point(47, 131);
            textBox_User.Name = "textBox_User";
            textBox_User.Size = new Size(648, 34);
            textBox_User.TabIndex = 4;
            // 
            // textBox_Pass
            // 
            textBox_Pass.Font = new Font("Segoe UI Emoji", 12F);
            textBox_Pass.Location = new Point(47, 251);
            textBox_Pass.Name = "textBox_Pass";
            textBox_Pass.Size = new Size(648, 34);
            textBox_Pass.TabIndex = 5;
            textBox_Pass.UseSystemPasswordChar = true;
            // 
            // textBox_cfPass
            // 
            textBox_cfPass.Font = new Font("Segoe UI Emoji", 12F);
            textBox_cfPass.Location = new Point(47, 375);
            textBox_cfPass.Name = "textBox_cfPass";
            textBox_cfPass.Size = new Size(648, 34);
            textBox_cfPass.TabIndex = 6;
            textBox_cfPass.UseSystemPasswordChar = true;
            // 
            // button_SignUp
            // 
            button_SignUp.AutoSize = true;
            button_SignUp.BackColor = SystemColors.ButtonHighlight;
            button_SignUp.FlatStyle = FlatStyle.Flat;
            button_SignUp.Font = new Font("Sitka Small", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_SignUp.Location = new Point(295, 445);
            button_SignUp.Name = "button_SignUp";
            button_SignUp.Size = new Size(155, 47);
            button_SignUp.TabIndex = 7;
            button_SignUp.Text = "Sign Up";
            button_SignUp.UseVisualStyleBackColor = false;
            button_SignUp.Click += button_SignUp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(334, 521);
            label1.Name = "label1";
            label1.Size = new Size(271, 29);
            label1.TabIndex = 8;
            label1.Text = "Already have an account?";
            // 
            // label_SwitchSignIn
            // 
            label_SwitchSignIn.AutoSize = true;
            label_SwitchSignIn.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_SwitchSignIn.ForeColor = Color.MediumBlue;
            label_SwitchSignIn.Location = new Point(606, 521);
            label_SwitchSignIn.Name = "label_SwitchSignIn";
            label_SwitchSignIn.Size = new Size(89, 29);
            label_SwitchSignIn.TabIndex = 9;
            label_SwitchSignIn.Text = "Sign In";
            label_SwitchSignIn.Click += label_SwitchSignIn_Click;
            // 
            // button_ShowPass
            // 
            button_ShowPass.AutoSize = true;
            button_ShowPass.BackColor = Color.Transparent;
            button_ShowPass.BackgroundImageLayout = ImageLayout.Zoom;
            button_ShowPass.FlatAppearance.BorderSize = 0;
            button_ShowPass.FlatStyle = FlatStyle.Flat;
            button_ShowPass.Location = new Point(701, 245);
            button_ShowPass.Name = "button_ShowPass";
            button_ShowPass.Size = new Size(40, 40);
            button_ShowPass.TabIndex = 10;
            button_ShowPass.UseVisualStyleBackColor = false;
            // 
            // button_show
            // 
            button_show.BackgroundImage = Properties.Resources.Thiết_kế_chưa_có_tên;
            button_show.BackgroundImageLayout = ImageLayout.Stretch;
            button_show.FlatAppearance.BorderSize = 0;
            button_show.FlatStyle = FlatStyle.Flat;
            button_show.Location = new Point(696, 245);
            button_show.Name = "button_show";
            button_show.Size = new Size(45, 45);
            button_show.TabIndex = 11;
            button_show.UseVisualStyleBackColor = true;
            button_show.Click += button_show_Click;
            // 
            // SignUp_BT5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrange;
            ClientSize = new Size(758, 594);
            Controls.Add(button_show);
            Controls.Add(button_ShowPass);
            Controls.Add(label_SwitchSignIn);
            Controls.Add(label1);
            Controls.Add(button_SignUp);
            Controls.Add(textBox_cfPass);
            Controls.Add(textBox_Pass);
            Controls.Add(textBox_User);
            Controls.Add(label_cfPass);
            Controls.Add(label_Pass);
            Controls.Add(label_UserName);
            Controls.Add(label_SignUp);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignUp_BT5";
            Text = "SIGN UP";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label_SignUp;
        private Label label_UserName;
        private Label label_Pass;
        private Label label_cfPass;
        private TextBox textBox_User;
        private TextBox textBox_Pass;
        private TextBox textBox_cfPass;
        private Button button_SignUp;
        private Label label1;
        private Label label_SwitchSignIn;
        private Button button_ShowPass;
        private Button button_show;
    }
}