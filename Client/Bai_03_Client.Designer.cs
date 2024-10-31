namespace Client
{
    partial class Bai_03_Client
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
            label_IPAddress = new Label();
            label_Port = new Label();
            textBox_IPAddress = new TextBox();
            textBox_Port = new TextBox();
            richTextBox_Chat = new RichTextBox();
            richTextBox_Message = new RichTextBox();
            label_Message = new Label();
            button_Send = new Button();
            button_Exit = new Button();
            button_Clear = new Button();
            button_ClearChat = new Button();
            button_Connect = new Button();
            button_Stop = new Button();
            SuspendLayout();
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label_Title.Location = new Point(204, 20);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(159, 34);
            label_Title.TabIndex = 0;
            label_Title.Text = "TCP Client";
            // 
            // label_IPAddress
            // 
            label_IPAddress.AutoSize = true;
            label_IPAddress.Location = new Point(36, 83);
            label_IPAddress.Name = "label_IPAddress";
            label_IPAddress.Size = new Size(104, 24);
            label_IPAddress.TabIndex = 1;
            label_IPAddress.Text = "IP Address";
            // 
            // label_Port
            // 
            label_Port.AutoSize = true;
            label_Port.Location = new Point(36, 118);
            label_Port.Name = "label_Port";
            label_Port.Size = new Size(46, 24);
            label_Port.TabIndex = 2;
            label_Port.Text = "Port";
            // 
            // textBox_IPAddress
            // 
            textBox_IPAddress.Location = new Point(146, 80);
            textBox_IPAddress.Name = "textBox_IPAddress";
            textBox_IPAddress.Size = new Size(183, 32);
            textBox_IPAddress.TabIndex = 3;
            // 
            // textBox_Port
            // 
            textBox_Port.Location = new Point(146, 115);
            textBox_Port.Name = "textBox_Port";
            textBox_Port.Size = new Size(183, 32);
            textBox_Port.TabIndex = 4;
            // 
            // richTextBox_Chat
            // 
            richTextBox_Chat.BackColor = SystemColors.Window;
            richTextBox_Chat.Location = new Point(35, 153);
            richTextBox_Chat.Name = "richTextBox_Chat";
            richTextBox_Chat.ReadOnly = true;
            richTextBox_Chat.Size = new Size(488, 254);
            richTextBox_Chat.TabIndex = 5;
            richTextBox_Chat.Text = "";
            // 
            // richTextBox_Message
            // 
            richTextBox_Message.Location = new Point(34, 444);
            richTextBox_Message.Name = "richTextBox_Message";
            richTextBox_Message.Size = new Size(489, 58);
            richTextBox_Message.TabIndex = 6;
            richTextBox_Message.Text = "";
            // 
            // label_Message
            // 
            label_Message.AutoSize = true;
            label_Message.Location = new Point(34, 417);
            label_Message.Name = "label_Message";
            label_Message.Size = new Size(87, 24);
            label_Message.TabIndex = 7;
            label_Message.Text = "Message";
            // 
            // button_Send
            // 
            button_Send.Location = new Point(412, 508);
            button_Send.Name = "button_Send";
            button_Send.Size = new Size(111, 45);
            button_Send.TabIndex = 8;
            button_Send.Text = "Send";
            button_Send.UseVisualStyleBackColor = true;
            button_Send.Click += button_Send_Click;
            // 
            // button_Exit
            // 
            button_Exit.Location = new Point(412, 566);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(111, 45);
            button_Exit.TabIndex = 9;
            button_Exit.Text = "Exit";
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // button_Clear
            // 
            button_Clear.Location = new Point(295, 566);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(111, 45);
            button_Clear.TabIndex = 10;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // button_ClearChat
            // 
            button_ClearChat.Location = new Point(146, 566);
            button_ClearChat.Name = "button_ClearChat";
            button_ClearChat.Size = new Size(143, 45);
            button_ClearChat.TabIndex = 11;
            button_ClearChat.Text = "Clear chat";
            button_ClearChat.UseVisualStyleBackColor = true;
            button_ClearChat.Click += button_ClearChat_Click;
            // 
            // button_Connect
            // 
            button_Connect.Location = new Point(398, 80);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(125, 32);
            button_Connect.TabIndex = 12;
            button_Connect.Text = "Connect";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // button_Stop
            // 
            button_Stop.Location = new Point(398, 118);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(125, 32);
            button_Stop.TabIndex = 13;
            button_Stop.Text = "Stop";
            button_Stop.UseVisualStyleBackColor = true;
            button_Stop.Click += button_Stop_Click;
            // 
            // Bai_03_Client
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 225, 107);
            ClientSize = new Size(563, 635);
            Controls.Add(button_Stop);
            Controls.Add(button_Connect);
            Controls.Add(button_ClearChat);
            Controls.Add(button_Clear);
            Controls.Add(button_Exit);
            Controls.Add(button_Send);
            Controls.Add(label_Message);
            Controls.Add(richTextBox_Message);
            Controls.Add(richTextBox_Chat);
            Controls.Add(textBox_Port);
            Controls.Add(textBox_IPAddress);
            Controls.Add(label_Port);
            Controls.Add(label_IPAddress);
            Controls.Add(label_Title);
            Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            Margin = new Padding(4);
            Name = "Bai_03_Client";
            Text = "BT3 _ TCP Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Title;
        private Label label_IPAddress;
        private Label label_Port;
        private TextBox textBox_IPAddress;
        private TextBox textBox_Port;
        private RichTextBox richTextBox_Chat;
        private RichTextBox richTextBox_Message;
        private Label label_Message;
        private Button button_Send;
        private Button button_Exit;
        private Button button_Clear;
        private Button button_ClearChat;
        private Button button_Connect;
        private Button button_Stop;
    }
}