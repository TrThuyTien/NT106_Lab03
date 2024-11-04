namespace Client
{
    partial class Bai_04_Client
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
            label_Title = new Label();
            button_Connect = new Button();
            button_Disconnect = new Button();
            textBox_Chat = new TextBox();
            label_Name = new Label();
            label_Message = new Label();
            textBox_Message = new TextBox();
            button_Send = new Button();
            textBox_Name = new TextBox();
            SuspendLayout();
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label_Title.Location = new Point(236, 21);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(140, 28);
            label_Title.TabIndex = 0;
            label_Title.Text = "Chat Room";
            // 
            // button_Connect
            // 
            button_Connect.Location = new Point(470, 392);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(99, 33);
            button_Connect.TabIndex = 7;
            button_Connect.Text = "Join";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // button_Disconnect
            // 
            button_Disconnect.Location = new Point(470, 443);
            button_Disconnect.Name = "button_Disconnect";
            button_Disconnect.Size = new Size(99, 33);
            button_Disconnect.TabIndex = 9;
            button_Disconnect.Text = "Out";
            button_Disconnect.UseVisualStyleBackColor = true;
            button_Disconnect.Click += button_Disconnect_Click;
            // 
            // textBox_Chat
            // 
            textBox_Chat.BackColor = SystemColors.Window;
            textBox_Chat.Location = new Point(38, 67);
            textBox_Chat.Multiline = true;
            textBox_Chat.Name = "textBox_Chat";
            textBox_Chat.ReadOnly = true;
            textBox_Chat.Size = new Size(531, 275);
            textBox_Chat.TabIndex = 10;
            // 
            // label_Name
            // 
            label_Name.AutoSize = true;
            label_Name.Location = new Point(38, 357);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(109, 24);
            label_Name.TabIndex = 11;
            label_Name.Text = "Your Name";
            // 
            // label_Message
            // 
            label_Message.AutoSize = true;
            label_Message.Location = new Point(38, 416);
            label_Message.Name = "label_Message";
            label_Message.Size = new Size(87, 24);
            label_Message.TabIndex = 12;
            label_Message.Text = "Message";
            // 
            // textBox_Message
            // 
            textBox_Message.Location = new Point(38, 443);
            textBox_Message.Name = "textBox_Message";
            textBox_Message.Size = new Size(308, 32);
            textBox_Message.TabIndex = 13;
            // 
            // button_Send
            // 
            button_Send.Location = new Point(365, 443);
            button_Send.Name = "button_Send";
            button_Send.Size = new Size(99, 33);
            button_Send.TabIndex = 14;
            button_Send.Text = "Send";
            button_Send.UseVisualStyleBackColor = true;
            button_Send.Click += button_Send_Click;
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(38, 381);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(154, 32);
            textBox_Name.TabIndex = 15;
            // 
            // Bai_04_Client
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 190, 105);
            ClientSize = new Size(616, 488);
            Controls.Add(textBox_Name);
            Controls.Add(button_Send);
            Controls.Add(textBox_Message);
            Controls.Add(label_Message);
            Controls.Add(label_Name);
            Controls.Add(textBox_Chat);
            Controls.Add(button_Disconnect);
            Controls.Add(button_Connect);
            Controls.Add(label_Title);
            Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            Margin = new Padding(4);
            Name = "Bai_04_Client";
            Text = "BT4 _ Client ChatRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Title;
        private Button button_Connect;
        private Button button_Disconnect;
        private TextBox textBox_Chat;
        private Label label_Name;
        private Label label_Message;
        private TextBox textBox_Message;
        private Button button_Send;
        private TextBox textBox_Name;
    }
}