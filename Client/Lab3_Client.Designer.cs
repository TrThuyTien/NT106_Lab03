namespace Client
{
    partial class Lab3_Client
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
            btn_BT1 = new Button();
            btn_BT2 = new Button();
            btn_BT3 = new Button();
            btn_BT4 = new Button();
            btn_BT5 = new Button();
            SuspendLayout();
            // 
            // btn_BT1
            // 
            btn_BT1.BackColor = Color.SteelBlue;
            btn_BT1.FlatStyle = FlatStyle.Flat;
            btn_BT1.Font = new Font("Cambria", 12F, FontStyle.Bold);
            btn_BT1.ForeColor = SystemColors.Window;
            btn_BT1.Location = new Point(121, 118);
            btn_BT1.Name = "btn_BT1";
            btn_BT1.Size = new Size(107, 42);
            btn_BT1.TabIndex = 0;
            btn_BT1.Text = "Bài 1";
            btn_BT1.UseVisualStyleBackColor = false;
            btn_BT1.Click += btn_BT1_Click;
            // 
            // btn_BT2
            // 
            btn_BT2.BackColor = Color.SteelBlue;
            btn_BT2.FlatStyle = FlatStyle.Flat;
            btn_BT2.Font = new Font("Cambria", 12F, FontStyle.Bold);
            btn_BT2.ForeColor = SystemColors.Window;
            btn_BT2.Location = new Point(322, 118);
            btn_BT2.Name = "btn_BT2";
            btn_BT2.Size = new Size(107, 42);
            btn_BT2.TabIndex = 1;
            btn_BT2.Text = "Bài 2";
            btn_BT2.UseVisualStyleBackColor = false;
            // 
            // btn_BT3
            // 
            btn_BT3.BackColor = Color.SteelBlue;
            btn_BT3.FlatStyle = FlatStyle.Flat;
            btn_BT3.Font = new Font("Cambria", 12F, FontStyle.Bold);
            btn_BT3.ForeColor = SystemColors.Window;
            btn_BT3.Location = new Point(527, 118);
            btn_BT3.Name = "btn_BT3";
            btn_BT3.Size = new Size(107, 42);
            btn_BT3.TabIndex = 2;
            btn_BT3.Text = "Bài 3";
            btn_BT3.UseVisualStyleBackColor = false;
            btn_BT3.Click += btn_BT3_Click;
            // 
            // btn_BT4
            // 
            btn_BT4.BackColor = Color.SteelBlue;
            btn_BT4.FlatStyle = FlatStyle.Flat;
            btn_BT4.Font = new Font("Cambria", 12F, FontStyle.Bold);
            btn_BT4.ForeColor = SystemColors.Window;
            btn_BT4.Location = new Point(221, 224);
            btn_BT4.Name = "btn_BT4";
            btn_BT4.Size = new Size(107, 42);
            btn_BT4.TabIndex = 3;
            btn_BT4.Text = "Bài 4";
            btn_BT4.UseVisualStyleBackColor = false;
            btn_BT4.Click += btn_BT4_Click;
            // 
            // btn_BT5
            // 
            btn_BT5.BackColor = Color.SteelBlue;
            btn_BT5.FlatStyle = FlatStyle.Flat;
            btn_BT5.Font = new Font("Cambria", 12F, FontStyle.Bold);
            btn_BT5.ForeColor = SystemColors.Window;
            btn_BT5.Location = new Point(430, 224);
            btn_BT5.Name = "btn_BT5";
            btn_BT5.Size = new Size(107, 42);
            btn_BT5.TabIndex = 4;
            btn_BT5.Text = "Bài 5";
            btn_BT5.UseVisualStyleBackColor = false;
            // 
            // Lab3_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 382);
            Controls.Add(btn_BT5);
            Controls.Add(btn_BT4);
            Controls.Add(btn_BT3);
            Controls.Add(btn_BT2);
            Controls.Add(btn_BT1);
            Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            Name = "Lab3_Client";
            Text = "Lab3_Client";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_BT1;
        private Button btn_BT2;
        private Button btn_BT3;
        private Button btn_BT4;
        private Button btn_BT5;
    }
}