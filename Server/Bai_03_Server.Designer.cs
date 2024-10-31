namespace Server
{
    partial class Bai_03_Server
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
            textBox_IPAddress = new TextBox();
            textBox_Port = new TextBox();
            label_Port = new Label();
            richTextBox_Chat = new RichTextBox();
            button_Listen = new Button();
            button_Stop = new Button();
            button_Exit = new Button();
            button_Clear = new Button();
            button_ClearChat = new Button();
            richTextBox_Message = new RichTextBox();
            label_Message = new Label();
            button_Send = new Button();
            SuspendLayout();
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label_Title.Location = new Point(215, 9);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(169, 34);
            label_Title.TabIndex = 0;
            label_Title.Text = "TCP Server";
            // 
            // label_IPAddress
            // 
            label_IPAddress.AutoSize = true;
            label_IPAddress.Location = new Point(63, 95);
            label_IPAddress.Name = "label_IPAddress";
            label_IPAddress.Size = new Size(104, 24);
            label_IPAddress.TabIndex = 1;
            label_IPAddress.Text = "IP Address";
            // 
            // textBox_IPAddress
            // 
            textBox_IPAddress.Location = new Point(173, 87);
            textBox_IPAddress.Name = "textBox_IPAddress";
            textBox_IPAddress.Size = new Size(188, 32);
            textBox_IPAddress.TabIndex = 2;
            // 
            // textBox_Port
            // 
            textBox_Port.Location = new Point(440, 87);
            textBox_Port.Name = "textBox_Port";
            textBox_Port.Size = new Size(90, 32);
            textBox_Port.TabIndex = 4;
            // 
            // label_Port
            // 
            label_Port.AutoSize = true;
            label_Port.Location = new Point(388, 95);
            label_Port.Name = "label_Port";
            label_Port.Size = new Size(46, 24);
            label_Port.TabIndex = 3;
            label_Port.Text = "Port";
            // 
            // richTextBox_Chat
            // 
            richTextBox_Chat.BackColor = SystemColors.Window;
            richTextBox_Chat.Location = new Point(65, 200);
            richTextBox_Chat.Name = "richTextBox_Chat";
            richTextBox_Chat.ReadOnly = true;
            richTextBox_Chat.Size = new Size(467, 213);
            richTextBox_Chat.TabIndex = 5;
            richTextBox_Chat.Text = "";
            // 
            // button_Listen
            // 
            button_Listen.Location = new Point(316, 136);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(106, 46);
            button_Listen.TabIndex = 6;
            button_Listen.Text = "Listen";
            button_Listen.UseVisualStyleBackColor = true;
            button_Listen.Click += button_Listen_Click;
            // 
            // button_Stop
            // 
            button_Stop.Location = new Point(428, 136);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(104, 46);
            button_Stop.TabIndex = 7;
            button_Stop.Text = "Stop";
            button_Stop.UseVisualStyleBackColor = true;
            button_Stop.Click += button_Stop_Click;
            // 
            // button_Exit
            // 
            button_Exit.Location = new Point(428, 591);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(104, 46);
            button_Exit.TabIndex = 8;
            button_Exit.Text = "Exit";
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // button_Clear
            // 
            button_Clear.Location = new Point(318, 591);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(104, 46);
            button_Clear.TabIndex = 9;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // button_ClearChat
            // 
            button_ClearChat.Location = new Point(149, 591);
            button_ClearChat.Name = "button_ClearChat";
            button_ClearChat.Size = new Size(163, 46);
            button_ClearChat.TabIndex = 10;
            button_ClearChat.Text = "Clear Chat";
            button_ClearChat.UseVisualStyleBackColor = true;
            button_ClearChat.Click += button_ClearChat_Click;
            // 
            // richTextBox_Message
            // 
            richTextBox_Message.Location = new Point(62, 461);
            richTextBox_Message.Name = "richTextBox_Message";
            richTextBox_Message.Size = new Size(471, 65);
            richTextBox_Message.TabIndex = 11;
            richTextBox_Message.Text = "";
            // 
            // label_Message
            // 
            label_Message.AutoSize = true;
            label_Message.Location = new Point(65, 434);
            label_Message.Name = "label_Message";
            label_Message.Size = new Size(87, 24);
            label_Message.TabIndex = 12;
            label_Message.Text = "Message";
            // 
            // button_Send
            // 
            button_Send.Location = new Point(429, 532);
            button_Send.Name = "button_Send";
            button_Send.Size = new Size(104, 46);
            button_Send.TabIndex = 13;
            button_Send.Text = "Send";
            button_Send.UseVisualStyleBackColor = true;
            button_Send.Click += button_Send_Click;
            // 
            // Bai_03_Server
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 158, 85);
            ClientSize = new Size(606, 649);
            Controls.Add(button_Send);
            Controls.Add(label_Message);
            Controls.Add(richTextBox_Message);
            Controls.Add(button_ClearChat);
            Controls.Add(button_Clear);
            Controls.Add(button_Exit);
            Controls.Add(button_Stop);
            Controls.Add(button_Listen);
            Controls.Add(richTextBox_Chat);
            Controls.Add(textBox_Port);
            Controls.Add(label_Port);
            Controls.Add(textBox_IPAddress);
            Controls.Add(label_IPAddress);
            Controls.Add(label_Title);
            Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            Margin = new Padding(4);
            Name = "Bai_03_Server";
            Text = "BT03 _ TCP Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Title;
        private Label label_IPAddress;
        private TextBox textBox_IPAddress;
        private TextBox textBox_Port;
        private Label label_Port;
        private RichTextBox richTextBox_Chat;
        private Button button_Listen;
        private Button button_Stop;
        private Button button_Exit;
        private Button button_Clear;
        private Button button_ClearChat;
        private RichTextBox richTextBox_Message;
        private Label label_Message;
        private Button button_Send;
    }
}