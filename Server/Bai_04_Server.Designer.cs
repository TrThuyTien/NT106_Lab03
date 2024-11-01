namespace Server
{
    partial class Bai_04_Server
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
            button_Listen = new Button();
            button_Stop = new Button();
            textBox_Editor = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(263, 22);
            label1.Name = "label1";
            label1.Size = new Size(88, 28);
            label1.TabIndex = 0;
            label1.Text = "Server";
            // 
            // button_Listen
            // 
            button_Listen.ForeColor = SystemColors.WindowText;
            button_Listen.Location = new Point(445, 419);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(110, 49);
            button_Listen.TabIndex = 2;
            button_Listen.Text = "Listen";
            button_Listen.UseVisualStyleBackColor = true;
            button_Listen.Click += button_Listen_Click;
            // 
            // button_Stop
            // 
            button_Stop.ForeColor = SystemColors.WindowText;
            button_Stop.Location = new Point(314, 419);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(110, 49);
            button_Stop.TabIndex = 3;
            button_Stop.Text = "Stop";
            button_Stop.UseVisualStyleBackColor = true;
            // 
            // textBox_Editor
            // 
            textBox_Editor.Location = new Point(57, 92);
            textBox_Editor.Multiline = true;
            textBox_Editor.Name = "textBox_Editor";
            textBox_Editor.Size = new Size(498, 285);
            textBox_Editor.TabIndex = 4;
            // 
            // Bai_04_Server
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(4, 154, 136);
            ClientSize = new Size(618, 495);
            Controls.Add(textBox_Editor);
            Controls.Add(button_Stop);
            Controls.Add(button_Listen);
            Controls.Add(label1);
            Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            ForeColor = SystemColors.Window;
            Margin = new Padding(4);
            Name = "Bai_04_Server";
            Text = "BT4 _ Server Room";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button_Listen;
        private Button button_Stop;
        private TextBox textBox_Editor;
    }
}