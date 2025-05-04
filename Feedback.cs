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
    public partial class Feedback : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Feedback()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check if facultyid exists in the faculty table
                string checkQuery = "SELECT COUNT(*) FROM faculty WHERE id = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@id", textBox1.Text);
                    int facultyCount = (int)checkCmd.ExecuteScalar();

                    if (facultyCount == 0)
                    {
                        MessageBox.Show("No such faculty found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Insert feedback if facultyid exists
                string query = "INSERT INTO FEEDBACK (studentid, facultyid, feedback) VALUES ((SELECT TOP 1 username FROM student_login ORDER BY login_timestamp DESC), @facultyid, @feedback)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@facultyid", textBox1.Text);
                    cmd.Parameters.AddWithValue("@feedback", textBox2.Text);

                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.ExecuteNonQuery();
                }


                MessageBox.Show("Feedback submitted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }

    }
}
