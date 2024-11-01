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
            textBox_Editor = new TextBox();
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
            button_Connect.Location = new Point(480, 431);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(99, 33);
            button_Connect.TabIndex = 7;
            button_Connect.Text = "Connect";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // button_Disconnect
            // 
            button_Disconnect.Location = new Point(344, 431);
            button_Disconnect.Name = "button_Disconnect";
            button_Disconnect.Size = new Size(130, 33);
            button_Disconnect.TabIndex = 9;
            button_Disconnect.Text = "Out";
            button_Disconnect.UseVisualStyleBackColor = true;
            button_Disconnect.Click += button_Disconnect_Click;
            // 
            // textBox_Editor
            // 
            textBox_Editor.Location = new Point(48, 83);
            textBox_Editor.Multiline = true;
            textBox_Editor.Name = "textBox_Editor";
            textBox_Editor.Size = new Size(531, 325);
            textBox_Editor.TabIndex = 10;
            textBox_Editor.TextChanged += textBox_Editor_TextChanged;
            // 
            // Bai_04_Client
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 190, 105);
            ClientSize = new Size(616, 488);
            Controls.Add(textBox_Editor);
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
        private TextBox textBox_Editor;
    }
}