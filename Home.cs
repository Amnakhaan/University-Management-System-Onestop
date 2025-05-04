using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onestop
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_login al = new Admin_login();
            al.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student_login sl = new Student_login();
            sl.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Faculty_login fl = new Faculty_login();
            fl.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
