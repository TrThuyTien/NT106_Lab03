namespace Server
{
    partial class Bai_01_Server
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
            label_Port = new Label();
            label_ReceiveMessages = new Label();
            richTextBox_ReceiveMessage = new RichTextBox();
            button_Listen = new Button();
            textBox_Port = new TextBox();
            button_Exit = new Button();
            button_Clear = new Button();
            label_Title = new Label();
            button_Stop = new Button();
            button_ClearReceiveMessages = new Button();
            SuspendLayout();
            // 
            // label_Port
            // 
            label_Port.AutoSize = true;
            label_Port.BackColor = Color.SkyBlue;
            label_Port.Font = new Font("Cambria", 12F);
            label_Port.Location = new Point(41, 95);
            label_Port.Name = "label_Port";
            label_Port.Size = new Size(47, 23);
            label_Port.TabIndex = 0;
            label_Port.Text = "Port";
            // 
            // label_ReceiveMessages
            // 
            label_ReceiveMessages.AutoSize = true;
            label_ReceiveMessages.BackColor = Color.SkyBlue;
            label_ReceiveMessages.Font = new Font("Cambria", 12F);
            label_ReceiveMessages.Location = new Point(44, 160);
            label_ReceiveMessages.Name = "label_ReceiveMessages";
            label_ReceiveMessages.Size = new Size(165, 23);
            label_ReceiveMessages.TabIndex = 1;
            label_ReceiveMessages.Text = "Receive messages";
            // 
            // richTextBox_ReceiveMessage
            // 
            richTextBox_ReceiveMessage.BackColor = SystemColors.Window;
            richTextBox_ReceiveMessage.Location = new Point(44, 196);
            richTextBox_ReceiveMessage.Name = "richTextBox_ReceiveMessage";
            richTextBox_ReceiveMessage.ReadOnly = true;
            richTextBox_ReceiveMessage.Size = new Size(524, 201);
            richTextBox_ReceiveMessage.TabIndex = 2;
            richTextBox_ReceiveMessage.Text = "";
            // 
            // button_Listen
            // 
            button_Listen.BackColor = Color.Azure;
            button_Listen.FlatStyle = FlatStyle.Flat;
            button_Listen.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button_Listen.Location = new Point(362, 90);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(100, 40);
            button_Listen.TabIndex = 3;
            button_Listen.Text = "Listen";
            button_Listen.UseVisualStyleBackColor = false;
            button_Listen.Click += button_Listen_Click;
            // 
            // textBox_Port
            // 
            textBox_Port.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            textBox_Port.Location = new Point(94, 90);
            textBox_Port.Multiline = true;
            textBox_Port.Name = "textBox_Port";
            textBox_Port.Size = new Size(149, 38);
            textBox_Port.TabIndex = 4;
            // 
            // button_Exit
            // 
            button_Exit.BackColor = Color.Azure;
            button_Exit.FlatAppearance.BorderColor = Color.Black;
            button_Exit.FlatStyle = FlatStyle.Flat;
            button_Exit.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button_Exit.ForeColor = SystemColors.Desktop;
            button_Exit.Location = new Point(468, 415);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(100, 40);
            button_Exit.TabIndex = 5;
            button_Exit.Text = "Exit";
            button_Exit.UseVisualStyleBackColor = false;
            button_Exit.Click += button_Exit_Click;
            // 
            // button_Clear
            // 
            button_Clear.BackColor = Color.Azure;
            button_Clear.FlatStyle = FlatStyle.Flat;
            button_Clear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button_Clear.Location = new Point(353, 415);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(100, 40);
            button_Clear.TabIndex = 6;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = false;
            button_Clear.Click += button_Clear_Click;
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label_Title.Location = new Point(231, 20);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(161, 33);
            label_Title.TabIndex = 7;
            label_Title.Text = "UDP Server";
            // 
            // button_Stop
            // 
            button_Stop.BackColor = Color.Azure;
            button_Stop.FlatStyle = FlatStyle.Flat;
            button_Stop.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button_Stop.Location = new Point(468, 90);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(100, 40);
            button_Stop.TabIndex = 8;
            button_Stop.Text = "Stop";
            button_Stop.UseVisualStyleBackColor = false;
            button_Stop.Click += button_Stop_Click;
            // 
            // button_ClearReceiveMessages
            // 
            button_ClearReceiveMessages.BackColor = Color.Azure;
            button_ClearReceiveMessages.FlatStyle = FlatStyle.Flat;
            button_ClearReceiveMessages.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button_ClearReceiveMessages.Location = new Point(44, 415);
            button_ClearReceiveMessages.Name = "button_ClearReceiveMessages";
            button_ClearReceiveMessages.Size = new Size(241, 40);
            button_ClearReceiveMessages.TabIndex = 9;
            button_ClearReceiveMessages.Text = "Clear Receive Messages";
            button_ClearReceiveMessages.UseVisualStyleBackColor = false;
            button_ClearReceiveMessages.Click += button_ClearReceiveMessages_Click;
            // 
            // Bai_01
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(607, 470);
            Controls.Add(button_ClearReceiveMessages);
            Controls.Add(button_Stop);
            Controls.Add(label_Title);
            Controls.Add(button_Clear);
            Controls.Add(button_Exit);
            Controls.Add(textBox_Port);
            Controls.Add(button_Listen);
            Controls.Add(richTextBox_ReceiveMessage);
            Controls.Add(label_ReceiveMessages);
            Controls.Add(label_Port);
            Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            Name = "Bai_01";
            Text = "BT1 _ UDP Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Port;
        private Label label_ReceiveMessages;
        private RichTextBox richTextBox_ReceiveMessage;
        private Button button_Listen;
        private TextBox textBox_Port;
        private Button button_Exit;
        private Button button_Clear;
        private Label label_Title;
        private Button button_Stop;
        private Button button_ClearReceiveMessages;
    }
}