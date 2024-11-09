using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Lab3_Client : Form
    {
        public Lab3_Client()
        {
            InitializeComponent();
        }

        private void btn_BT1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai_01_Client().ShowDialog();
            this.Show();
        }

        private void btn_BT3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai_03_Client().ShowDialog();
            this.Show();
        }

        private void btn_BT4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai_04_Client().ShowDialog();
            this.Show();
        }

        private void btn_BT5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignIn_BT5().ShowDialog();
            this.Show();
        }
    }
}
