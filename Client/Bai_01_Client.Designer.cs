

namespace Client
{
    partial class Bai_01_Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_IPRemoteHost = new Label();
            textBox_IPRemote = new TextBox();
            textBox_Port = new TextBox();
            label_Port = new Label();
            richTextBox_Message = new RichTextBox();
            label_Message = new Label();
            button_Send = new Button();
            button_Clear = new Button();
            button_ClearMessage = new Button();
            label_Title = new Label();
            SuspendLayout();
            // 
            // label_IPRemoteHost
            // 
            label_IPRemoteHost.AutoSize = true;
            label_IPRemoteHost.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_IPRemoteHost.Location = new Point(99, 108);
            label_IPRemoteHost.Name = "label_IPRemoteHost";
            label_IPRemoteHost.Size = new Size(147, 23);
            label_IPRemoteHost.TabIndex = 0;
            label_IPRemoteHost.Text = "IP Remote host";
            // 
            // textBox_IPRemote
            // 
            textBox_IPRemote.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_IPRemote.Location = new Point(99, 134);
            textBox_IPRemote.Name = "textBox_IPRemote";
            textBox_IPRemote.Size = new Size(211, 31);
            textBox_IPRemote.TabIndex = 1;
            // 
            // textBox_Port
            // 
            textBox_Port.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_Port.Location = new Point(362, 134);
            textBox_Port.Name = "textBox_Port";
            textBox_Port.Size = new Size(140, 31);
            textBox_Port.TabIndex = 3;
            // 
            // label_Port
            // 
            label_Port.AutoSize = true;
            label_Port.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Port.Location = new Point(362, 108);
            label_Port.Name = "label_Port";
            label_Port.Size = new Size(49, 23);
            label_Port.TabIndex = 2;
            label_Port.Text = "Port";
            // 
            // richTextBox_Message
            // 
            richTextBox_Message.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_Message.Location = new Point(94, 210);
            richTextBox_Message.Name = "richTextBox_Message";
            richTextBox_Message.Size = new Size(408, 187);
            richTextBox_Message.TabIndex = 4;
            richTextBox_Message.Text = "";
            // 
            // label_Message
            // 
            label_Message.AutoSize = true;
            label_Message.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Message.Location = new Point(94, 184);
            label_Message.Name = "label_Message";
            label_Message.Size = new Size(88, 23);
            label_Message.TabIndex = 5;
            label_Message.Text = "Message";
            // 
            // button_Send
            // 
            button_Send.Cursor = Cursors.Hand;
            button_Send.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Send.Image = Properties.Resources.message;
            button_Send.ImageAlign = ContentAlignment.MiddleLeft;
            button_Send.Location = new Point(396, 412);
            button_Send.Name = "button_Send";
            button_Send.Padding = new Padding(6, 4, 6, 4);
            button_Send.Size = new Size(106, 41);
            button_Send.TabIndex = 6;
            button_Send.Text = "Send";
            button_Send.TextAlign = ContentAlignment.MiddleRight;
            button_Send.UseVisualStyleBackColor = true;
            button_Send.Click += button_Send_Click;
            // 
            // button_Clear
            // 
            button_Clear.Cursor = Cursors.Hand;
            button_Clear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Clear.ForeColor = SystemColors.Desktop;
            button_Clear.Location = new Point(280, 412);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(106, 41);
            button_Clear.TabIndex = 7;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // button_ClearMessage
            // 
            button_ClearMessage.Cursor = Cursors.Hand;
            button_ClearMessage.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ClearMessage.Location = new Point(94, 412);
            button_ClearMessage.Name = "button_ClearMessage";
            button_ClearMessage.Size = new Size(167, 41);
            button_ClearMessage.TabIndex = 8;
            button_ClearMessage.Text = "Clear Message";
            button_ClearMessage.UseVisualStyleBackColor = true;
            button_ClearMessage.Click += button_ClearMessage_Click;
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Cambria", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label_Title.Location = new Point(225, 40);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(161, 36);
            label_Title.TabIndex = 9;
            label_Title.Text = "UDP Client";
            // 
            // Bai_01_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(618, 489);
            Controls.Add(label_Title);
            Controls.Add(button_ClearMessage);
            Controls.Add(button_Clear);
            Controls.Add(button_Send);
            Controls.Add(label_Message);
            Controls.Add(richTextBox_Message);
            Controls.Add(textBox_Port);
            Controls.Add(label_Port);
            Controls.Add(textBox_IPRemote);
            Controls.Add(label_IPRemoteHost);
            Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Bai_01_Client";
            Text = "BT1 _ UDP Client";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label_IPRemoteHost;
        private TextBox textBox_IPRemote;
        private TextBox textBox_Port;
        private Label label_Port;
        private RichTextBox richTextBox_Message;
        private Label label_Message;
        private Button button_Send;
        private Button button_Clear;
        private Button button_ClearMessage;
        private Label label_Title;
    }
}
