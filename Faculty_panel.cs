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
    public partial class Faculty_panel : Form
    {
        public Faculty_panel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            viewcalendarfac vc = new viewcalendarfac();
            vc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            viewfeedback vf = new viewfeedback();
            vf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Viewsalary vs = new Viewsalary();
            vs.Show();
            this.Hide();
        }
    }
}
