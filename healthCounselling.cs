using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onestop
{
    public partial class healthCounselling : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public healthCounselling()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_panel c = new Student_panel();
            c.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string Counsellor = "Dr Amna Ali";
                string insertQuery = "INSERT INTO counselling (counsellor) VALUES (@Counsellor);";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@CounsellingType", Counsellor);
                insertCommand.ExecuteNonQuery();

            }*/
            //MessageBox.Show("Mental Health Counsellor Selected Successfully");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
            //MessageBox.Show("Mental Health Counsellor Selected Successfully");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            //MessageBox.Show("Mental Health Counsellor Selected Successfully");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
            //MessageBox.Show("Mental Health Counsellor Selected Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mental Health Counsellor Selected Successfully");
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }
    }
}
