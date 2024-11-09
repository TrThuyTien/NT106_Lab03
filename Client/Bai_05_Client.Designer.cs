namespace Client
{
    partial class Bai_05_Client
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
            richTextBox_Chat = new RichTextBox();
            comboBox_Room = new ComboBox();
            textBox_RoomID = new TextBox();
            button_Connect = new Button();
            button_Send = new Button();
            richTextBox_Message = new RichTextBox();
            button_Disconnect = new Button();
            SuspendLayout();
            // 
            // richTextBox_Chat
            // 
            richTextBox_Chat.Location = new Point(12, 12);
            richTextBox_Chat.Name = "richTextBox_Chat";
            richTextBox_Chat.Size = new Size(595, 401);
            richTextBox_Chat.TabIndex = 0;
            richTextBox_Chat.Text = "";
            // 
            // comboBox_Room
            // 
            comboBox_Room.FormattingEnabled = true;
            comboBox_Room.Items.AddRange(new object[] { "Create Room", "Join Room" });
            comboBox_Room.Location = new Point(10, 420);
            comboBox_Room.Name = "comboBox_Room";
            comboBox_Room.Size = new Size(130, 28);
            comboBox_Room.TabIndex = 1;
            // 
            // textBox_RoomID
            // 
            textBox_RoomID.Location = new Point(146, 421);
            textBox_RoomID.Name = "textBox_RoomID";
            textBox_RoomID.Size = new Size(207, 27);
            textBox_RoomID.TabIndex = 2;
            // 
            // button_Connect
            // 
            button_Connect.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Connect.Location = new Point(359, 420);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(114, 28);
            button_Connect.TabIndex = 3;
            button_Connect.Text = "GO";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // button_Send
            // 
            button_Send.Location = new Point(12, 467);
            button_Send.Name = "button_Send";
            button_Send.Size = new Size(104, 29);
            button_Send.TabIndex = 4;
            button_Send.Text = "Send";
            button_Send.UseVisualStyleBackColor = true;
            button_Send.Click += button_Send_Click;
            // 
            // richTextBox_Message
            // 
            richTextBox_Message.Location = new Point(122, 467);
            richTextBox_Message.Name = "richTextBox_Message";
            richTextBox_Message.Size = new Size(485, 29);
            richTextBox_Message.TabIndex = 5;
            richTextBox_Message.Text = "";
            // 
            // button_Disconnect
            // 
            button_Disconnect.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Disconnect.Location = new Point(493, 419);
            button_Disconnect.Name = "button_Disconnect";
            button_Disconnect.Size = new Size(114, 28);
            button_Disconnect.TabIndex = 6;
            button_Disconnect.Text = "Quit";
            button_Disconnect.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Disconnect.UseVisualStyleBackColor = true;
            button_Disconnect.Click += button_Disconnect_Click;
            // 
            // Bai_05_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 512);
            Controls.Add(button_Disconnect);
            Controls.Add(richTextBox_Message);
            Controls.Add(button_Send);
            Controls.Add(button_Connect);
            Controls.Add(textBox_RoomID);
            Controls.Add(comboBox_Room);
            Controls.Add(richTextBox_Chat);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai_05_Client";
            Text = "CLIENT";
            ResumeLayout(false);
            PerformLayout();
        }

        private RichTextBox richTextBox_Chat;
        private ComboBox comboBox_Room;
        private TextBox textBox_RoomID;
        private Button button_Connect;
        private Button button_Send;
        private RichTextBox richTextBox_Message;
        #endregion

        private Button button_Disconnect;
    }
}