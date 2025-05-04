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
    public partial class Carcounselling : Form
    {
        public Carcounselling()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_panel c = new Student_panel();
            c.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Career Counsellor Selected Successfully");
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }
    }
}
