namespace Server
{
    partial class Bai_02_Server
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
            button_Listen = new Button();
            richTextBox_Content = new RichTextBox();
            SuspendLayout();
            // 
            // button_Listen
            // 
            button_Listen.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Listen.Location = new Point(485, 32);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(122, 56);
            button_Listen.TabIndex = 1;
            button_Listen.Text = "Listen";
            button_Listen.UseVisualStyleBackColor = true;
            button_Listen.Click += button_Listen_Click;
            // 
            // richTextBox_Content
            // 
            richTextBox_Content.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_Content.Location = new Point(56, 122);
            richTextBox_Content.Name = "richTextBox_Content";
            richTextBox_Content.ReadOnly = true;
            richTextBox_Content.Size = new Size(547, 335);
            richTextBox_Content.TabIndex = 2;
            richTextBox_Content.Text = "";
            // 
            // Bai_02_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 98, 71);
            ClientSize = new Size(670, 528);
            Controls.Add(richTextBox_Content);
            Controls.Add(button_Listen);
            Name = "Bai_02_Server";
            Text = "Bai_02_Server";
            ResumeLayout(false);
        }

        #endregion
        private Button button_Listen;
        private RichTextBox richTextBox_Content;
    }
}