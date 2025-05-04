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
    public partial class viewtranscript : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public viewtranscript()
        {
            InitializeComponent();
            DisplayRecentTranscriptData();
        }
        private void DisplayRecentTranscriptData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the recently logged-in student ID
                    string recentStudentIdQuery = @"
                SELECT TOP 1 username
                FROM student_login
                ORDER BY login_timestamp DESC
            ";

                    SqlCommand recentStudentIdCommand = new SqlCommand(recentStudentIdQuery, connection);
                    string recentStudentId = recentStudentIdCommand.ExecuteScalar()?.ToString();

                    textBox1.Text = recentStudentId;

                    // Get the semester number marked as 'done' for the recent student
                    string recentSemesterQuery = @"
                SELECT TOP 1 semesterno
                FROM (
                    SELECT 1 AS semesterno, sem1 FROM requesttranscriptids WHERE studentid = @studentid AND sem1 = 'done' UNION
                    SELECT 2 AS semesterno, sem2 FROM requesttranscriptids WHERE studentid = @studentid AND sem2 = 'done' UNION
                    SELECT 3 AS semesterno, sem3 FROM requesttranscriptids WHERE studentid = @studentid AND sem3 = 'done' UNION
                    SELECT 4 AS semesterno, sem4 FROM requesttranscriptids WHERE studentid = @studentid AND sem4 = 'done' UNION
                    SELECT 5 AS semesterno, sem5 FROM requesttranscriptids WHERE studentid = @studentid AND sem5 = 'done' UNION
                    SELECT 6 AS semesterno, sem6 FROM requesttranscriptids WHERE studentid = @studentid AND sem6 = 'done' UNION
                    SELECT 7 AS semesterno, sem7 FROM requesttranscriptids WHERE studentid = @studentid AND sem7 = 'done' UNION
                    SELECT 8 AS semesterno, sem8 FROM requesttranscriptids WHERE studentid = @studentid AND sem8 = 'done'
                ) AS RecentSemesters
                ORDER BY semesterno DESC
            ";

                    SqlCommand recentSemesterCommand = new SqlCommand(recentSemesterQuery, connection);
                    recentSemesterCommand.Parameters.AddWithValue("@studentid", recentStudentId);
                    string recentSemester = recentSemesterCommand.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(recentSemester))
                    {
                        textBox2.Text = recentSemester;

                        // Retrieve course and grade information for the recent student and semester
                        string retrieveTranscriptQuery = @"
                    SELECT course1, course2, course3, course4, course5, grade1, grade2, grade3, grade4, grade5
                    FROM transcript
                    WHERE studentid = @studentid AND semesterno = @semesterno
                ";

                        SqlCommand retrieveTranscriptCommand = new SqlCommand(retrieveTranscriptQuery, connection);
                        retrieveTranscriptCommand.Parameters.AddWithValue("@studentid", recentStudentId);
                        retrieveTranscriptCommand.Parameters.AddWithValue("@semesterno", recentSemester);

                        SqlDataReader reader = retrieveTranscriptCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            textBox3.Text = reader["course1"].ToString();
                            textBox4.Text = reader["course2"].ToString();
                            textBox5.Text = reader["course3"].ToString();
                            textBox6.Text = reader["course4"].ToString();
                            textBox7.Text = reader["course5"].ToString();

                            textBox8.Text = reader["grade1"].ToString();
                            textBox9.Text = reader["grade2"].ToString();
                            textBox10.Text = reader["grade3"].ToString();
                            textBox11.Text = reader["grade4"].ToString();
                            textBox12.Text = reader["grade5"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Transcript data not found for the recent student and semester.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Semester marked as 'done' not found for the recent student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
