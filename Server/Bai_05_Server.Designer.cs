namespace Server
{
    partial class Bai_05_Server
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
            label1 = new Label();
            richTextBox_Messages = new RichTextBox();
            button_Stop = new Button();
            button_Listen = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(267, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 28);
            label1.TabIndex = 1;
            label1.Text = "SERVER";
            // 
            // richTextBox_Messages
            // 
            richTextBox_Messages.Location = new Point(16, 40);
            richTextBox_Messages.Name = "richTextBox_Messages";
            richTextBox_Messages.Size = new Size(595, 425);
            richTextBox_Messages.TabIndex = 2;
            richTextBox_Messages.Text = "";
            // 
            // button_Stop
            // 
            button_Stop.FlatStyle = FlatStyle.Popup;
            button_Stop.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold);
            button_Stop.Location = new Point(158, 471);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(98, 29);
            button_Stop.TabIndex = 3;
            button_Stop.Text = "STOP";
            button_Stop.UseVisualStyleBackColor = true;
            button_Stop.Click += button_Stop_Click;
            // 
            // button_Listen
            // 
            button_Listen.FlatStyle = FlatStyle.Popup;
            button_Listen.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold);
            button_Listen.Location = new Point(347, 471);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(98, 29);
            button_Listen.TabIndex = 4;
            button_Listen.Text = "LISTEN";
            button_Listen.UseVisualStyleBackColor = true;
            button_Listen.Click += button_Listen_Click;
            // 
            // Bai_05_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 512);
            Controls.Add(button_Listen);
            Controls.Add(button_Stop);
            Controls.Add(richTextBox_Messages);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai_05_Server";
            Text = "SERVER";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox_Messages;
        private Button button_Stop;
        private Button button_Listen;
    }
}