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
    public partial class counselling : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public counselling()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string counsellingType = "Career Counselling";
                string insertQuery = "INSERT INTO counselling (type) VALUES (@CounsellingType);";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@CounsellingType", counsellingType);
                insertCommand.ExecuteNonQuery();

            }


            Carcounselling cc = new Carcounselling();
            cc.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string counsellingType = "Mental Health Counselling";
                string insertQuery = "INSERT INTO counselling (type) VALUES (@CounsellingType);";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@CounsellingType", counsellingType);
                insertCommand.ExecuteNonQuery();

            }

            healthCounselling hc = new healthCounselling();
            hc.Show();
            this.Hide();
        }
    }
}
