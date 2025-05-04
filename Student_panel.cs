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
    public partial class Student_panel : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Student_panel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            viewchallan vc = new viewchallan();
            vc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Viewcalendar vc = new Viewcalendar();
            vc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counselling c = new counselling();
            c.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lostandfound_student s = new lostandfound_student();
            s.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Feedback f = new Feedback();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //issue degree
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to retrieve the most recently logged-in student ID
                    string studentIdQuery = @"
                SELECT TOP 1 username
                FROM student_login
                ORDER BY login_timestamp DESC
            ";

                    SqlCommand studentIdCommand = new SqlCommand(studentIdQuery, connection);
                    string studentId = studentIdCommand.ExecuteScalar()?.ToString();

                    // Check if the student ID exists in the requestdegreeids table
                    string checkStatusQuery = @"
                SELECT status
                FROM requestdegreeids
                WHERE studentid = @studentid
            ";

                    SqlCommand checkStatusCommand = new SqlCommand(checkStatusQuery, connection);
                    checkStatusCommand.Parameters.AddWithValue("@studentid", studentId);
                    string status = checkStatusCommand.ExecuteScalar()?.ToString();

                    if (status == "done")
                    {
                        viewdegree d = new viewdegree();
                        d.Show();
                        this.Hide();
                    }
                    else
                    {
                        int count = 0;

                        // Check if the student ID exists in the requestdegreeids table
                        string checkExistingQuery = @"
                    SELECT COUNT(*)
                    FROM requestdegreeids
                    WHERE studentid = @studentid
                ";

                        SqlCommand checkExistingCommand = new SqlCommand(checkExistingQuery, connection);
                        checkExistingCommand.Parameters.AddWithValue("@studentid", studentId);
                        count = (int)checkExistingCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            // SQL query to insert the student ID into the requestdegreeids table
                            string insertQuery = @"
                        INSERT INTO requestdegreeids (studentid) 
                        VALUES (@studentid)
                    ";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@studentid", studentId);
                            insertCommand.ExecuteNonQuery();

                            MessageBox.Show("Request sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            waitfordegree w = new waitfordegree();
                            w.Show();
                            this.Hide();
                        }
                        else
                        {
                            waitfordegree w = new waitfordegree();
                            w.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //ID Card
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string studentIdQuery = @"
                SELECT TOP 1 username
                FROM student_login
                ORDER BY login_timestamp DESC
            ";

                    SqlCommand studentIdCommand = new SqlCommand(studentIdQuery, connection);
                    string studentId = studentIdCommand.ExecuteScalar()?.ToString();

                    string checkStatusQuery = @"
                SELECT status
                FROM requestidcardids
                WHERE studentid = @studentid
            ";

                    SqlCommand checkStatusCommand = new SqlCommand(checkStatusQuery, connection);
                    checkStatusCommand.Parameters.AddWithValue("@studentid", studentId);
                    string status = checkStatusCommand.ExecuteScalar()?.ToString();

                    if (status == "done")
                    {
                        viewIDCard viewIdCardForm = new viewIDCard();
                        viewIdCardForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        int count = 0;

                        // Check if the student ID exists in the requestidcardids table
                        string checkExistingQuery = @"
                    SELECT COUNT(*)
                    FROM requestidcardids
                    WHERE studentid = @studentid
                ";

                        SqlCommand checkExistingCommand = new SqlCommand(checkExistingQuery, connection);
                        checkExistingCommand.Parameters.AddWithValue("@studentid", studentId);
                        count = (int)checkExistingCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            // SQL query to insert the student ID into the requestidcardids table
                            string insertQuery = @"
                        INSERT INTO requestidcardids (studentid) 
                        VALUES (@studentid)
                    ";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@studentid", studentId);
                            insertCommand.ExecuteNonQuery();

                            MessageBox.Show("Request sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            waitforIDcard w = new waitforIDcard();
                            w.Show();
                            this.Hide();
                        }
                        else
                        {
                            waitforIDcard w = new waitforIDcard();
                            w.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // transcript
            semesterfortranscript sft = new semesterfortranscript();
            sft.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            internships internships = new internships();
            internships.Show();
            this.Hide();
        }
    }
}
