using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace onestop
{
    public partial class semesterfortranscript : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public semesterfortranscript()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get the most recently logged-in student ID from student_login table
                string studentId = GetLatestLoggedInStudentId(connection);

                if (!string.IsNullOrEmpty(studentId))
                {
                    string selectedSemester = comboBox1.SelectedItem.ToString();
                    string columnToUpdate = "sem" + selectedSemester;

                    // Check if the selected semester's column is empty or 'requested'
                    string status = CheckSemesterStatus(connection, studentId, columnToUpdate);

                    if (status == "done")
                    {
                        // Navigate to viewtranscript form
                        viewtranscript v = new viewtranscript();
                        v.Show();
                        this.Hide();
                    }
                    else if (status == "requested")
                    {
                        // Navigate to waitfortranscript form
                        waitfortranscript w = new waitfortranscript();
                        w.Show();
                        this.Hide();
                    }
                    else
                    {
                        //// Insert 'requested' status and current time into requesttranscriptids table
                        //string insertQuery = $"INSERT INTO requesttranscriptids (studentid, {columnToUpdate}, login_timestamp) VALUES (@studentid, 'requested', @timestamp)";
                        //SqlCommand command = new SqlCommand(insertQuery, connection);
                        //command.Parameters.AddWithValue("@studentid", studentId);
                        //command.Parameters.AddWithValue("@timestamp", DateTime.Now); // Use current time
                        //command.ExecuteNonQuery();

                        // Construct the query dynamically
                        string insertQuery = $@"
                        IF EXISTS (SELECT 1 FROM requesttranscriptids WHERE studentid = @studentid)
                        BEGIN
                            UPDATE requesttranscriptids 
                            SET {columnToUpdate} = 'requested',
                                login_timestamp = @timestamp
                            WHERE studentid = @studentid;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO requesttranscriptids (studentid, {columnToUpdate}, login_timestamp) 
                            VALUES (@studentid, 'requested', @timestamp);
                        END";

                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@studentid", studentId);
                        command.Parameters.AddWithValue("@timestamp", DateTime.Now); // Use current time
                        command.ExecuteNonQuery();






                        MessageBox.Show("Request sent successfully.");

                        waitfortranscript sp = new waitfortranscript();
                        sp.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("No logged in student found.");
                }
            }
        }

        private string GetLatestLoggedInStudentId(SqlConnection connection)
        {
            string studentIdQuery = @"
        SELECT TOP 1 username
        FROM student_login
        ORDER BY login_timestamp DESC
    ";

            SqlCommand studentIdCommand = new SqlCommand(studentIdQuery, connection);
            return studentIdCommand.ExecuteScalar()?.ToString();
        }


        private string CheckSemesterStatus(SqlConnection connection, string studentId, string columnToUpdate)
        {
            string query = $"SELECT {columnToUpdate} FROM requesttranscriptids WHERE studentid = @studentid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentid", studentId);
            var result = command.ExecuteScalar();
            return result == null ? "" : result.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Add your code here if you need to handle the selection change event of comboBox1
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Add your code here if you need to handle the value change event of dateTimePicker1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }
    }
}
