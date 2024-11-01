namespace Server
{
    public partial class Lab3_Server : Form
    {
        public Lab3_Server()
        {
            InitializeComponent();
        }

        private void button_Bai01_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai_01().ShowDialog();
            this.Show();
        }

        private void button_Bai3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai_03_Server().ShowDialog();
            this.Show();
        }

        private void button_Bai4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai_04_Server().ShowDialog();
            this.Show();
        }
    }
}
