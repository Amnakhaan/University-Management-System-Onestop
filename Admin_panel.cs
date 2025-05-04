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
    public partial class Admin_panel : Form
    {
        public Admin_panel()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Salary s = new Salary();
            s.Show();
            this.Hide();
        }

        private void Admin_panel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home ap = new Home();
            ap.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register_Students rs = new Register_Students();
            rs.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register_Faculty rf = new Register_Faculty();
            rf.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            issue_feechallan ifc = new issue_feechallan();
            ifc.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            degreeissuance isd = new degreeissuance();
            isd.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Academic_calendar ac = new Academic_calendar();
            ac.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lostandfound_admin a = new lostandfound_admin();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IssueIDcard mic = new IssueIDcard();
            mic.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Issuetranscript it = new Issuetranscript();
            it.Show();
            this.Hide();
        }
    }
}
