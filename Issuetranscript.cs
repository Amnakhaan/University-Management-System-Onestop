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
    public partial class Issuetranscript : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Issuetranscript()
        {
            InitializeComponent();
            DisplayTranscriptData();
        }
        private void DisplayTranscriptData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct the SQL query to select the student ID and non-empty columns
                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append("SELECT studentid");

                    // Add non-empty columns dynamically
                    for (int i = 1; i <= 8; i++)
                    {
                        string columnName = "sem" + i;
                        queryBuilder.AppendFormat(", CASE WHEN [{0}] IS NOT NULL THEN [{0}] ELSE '' END AS [{0}]", columnName);
                    }

                    queryBuilder.Append(" FROM requesttranscriptids");

                    // Create a SqlDataAdapter to fetch the data
                    SqlDataAdapter adapter = new SqlDataAdapter(queryBuilder.ToString(), connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Issuetranscript_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = textBox1.Text.Trim();

                if (!string.IsNullOrEmpty(studentId))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Check if the student ID exists in the requesttranscriptids table
                        string checkStudentQuery = "SELECT COUNT(*) FROM requesttranscriptids WHERE studentid = @studentid";
                        using (SqlCommand checkStudentCommand = new SqlCommand(checkStudentQuery, connection))
                        {
                            checkStudentCommand.Parameters.AddWithValue("@studentid", studentId);
                            int count = (int)checkStudentCommand.ExecuteScalar();

                            if (count == 1)
                            {
                                // Fetch student details from the student table
                                string fetchStudentQuery = "SELECT firstname, department FROM student WHERE id = @studentid";
                                using (SqlCommand fetchStudentCommand = new SqlCommand(fetchStudentQuery, connection))
                                {
                                    fetchStudentCommand.Parameters.AddWithValue("@studentid", studentId);
                                    SqlDataReader reader = fetchStudentCommand.ExecuteReader();

                                    if (reader.Read())
                                    {
                                        textBox2.Text = reader["firstname"].ToString(); // Display student name
                                        textBox3.Text = reader["department"].ToString(); // Display department
                                    }
                                    else
                                    {
                                        MessageBox.Show("Student details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    reader.Close();
                                }

                                // Find the first requested semester for the student
                                string findSemesterQuery = @"
                            SELECT TOP 1
                                CASE
                                    WHEN sem1 = 'requested' THEN '1'
                                    WHEN sem2 = 'requested' THEN '2'
                                    WHEN sem3 = 'requested' THEN '3'
                                    WHEN sem4 = 'requested' THEN '4'
                                    WHEN sem5 = 'requested' THEN '5'
                                    WHEN sem6 = 'requested' THEN '6'
                                    WHEN sem7 = 'requested' THEN '7'
                                    WHEN sem8 = 'requested' THEN '8'
                                    ELSE NULL
                                END AS requestedSemester
                            FROM requesttranscriptids
                            WHERE studentid = @studentid
                            ORDER BY requestedSemester ASC";
                                using (SqlCommand findSemesterCommand = new SqlCommand(findSemesterQuery, connection))
                                {
                                    findSemesterCommand.Parameters.AddWithValue("@studentid", studentId);
                                    object requestedSemester = findSemesterCommand.ExecuteScalar();
                                    if (requestedSemester != null && requestedSemester != DBNull.Value)
                                    {
                                        textBox4.Text = requestedSemester.ToString(); // Display requested semester
                                    }
                                    else
                                    {
                                        MessageBox.Show("No requested semester found for the student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Student ID not found in requesttranscriptids table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = textBox1.Text.Trim();
                string semesterNo = textBox4.Text.Trim();

                if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(semesterNo))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Check if the combination of student ID and semester already exists in the transcript table
                        string checkExistingQuery = @"
                    SELECT COUNT(*)
                    FROM transcript
                    WHERE studentid = @studentid AND semesterno = @semesterNo
                ";

                        SqlCommand checkExistingCommand = new SqlCommand(checkExistingQuery, connection);
                        checkExistingCommand.Parameters.AddWithValue("@studentid", studentId);
                        checkExistingCommand.Parameters.AddWithValue("@semesterNo", semesterNo);
                        int count = (int)checkExistingCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Transcript already issued for this student and semester combination.", "Already Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Insert values into transcript table
                            string insertQuery = @"
                        INSERT INTO transcript (studentid, semesterno, course1, course2, course3, course4, course5, grade1, grade2, grade3, grade4, grade5)
                        VALUES (@studentid, @semesterNo, @course1, @course2, @course3, @course4, @course5, @grade1, @grade2, @grade3, @grade4, @grade5)
                    ";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@studentid", studentId);
                            insertCommand.Parameters.AddWithValue("@semesterNo", semesterNo);
                            insertCommand.Parameters.AddWithValue("@course1", textBox5.Text.Trim());
                            insertCommand.Parameters.AddWithValue("@course2", textBox6.Text.Trim());
                            insertCommand.Parameters.AddWithValue("@course3", textBox7.Text.Trim());
                            insertCommand.Parameters.AddWithValue("@course4", textBox8.Text.Trim());
                            insertCommand.Parameters.AddWithValue("@course5", textBox9.Text.Trim());
                            insertCommand.Parameters.AddWithValue("@grade1", comboBox1.SelectedItem.ToString());
                            insertCommand.Parameters.AddWithValue("@grade2", comboBox2.SelectedItem.ToString());
                            insertCommand.Parameters.AddWithValue("@grade3", comboBox3.SelectedItem.ToString());
                            insertCommand.Parameters.AddWithValue("@grade4", comboBox4.SelectedItem.ToString());
                            insertCommand.Parameters.AddWithValue("@grade5", comboBox5.SelectedItem.ToString());

                            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null || comboBox5.SelectedItem == null)
                            {
                                MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                insertCommand.ExecuteNonQuery();

                                // Update status in requesttranscriptids table
                                string updateStatusQuery = @"
                                UPDATE requesttranscriptids
                                SET sem{0} = 'done'
                                WHERE studentid = @studentid
                                ";
                                SqlCommand updateStatusCommand = new SqlCommand(string.Format(updateStatusQuery, semesterNo), connection);
                                updateStatusCommand.Parameters.AddWithValue("@studentid", studentId);
                                updateStatusCommand.ExecuteNonQuery();

                                MessageBox.Show("Transcript issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a student ID and semester number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
