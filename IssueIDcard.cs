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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace onestop
{
    public partial class IssueIDcard : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public IssueIDcard()
        {
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from requestidcardids", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = textBox1.Text.Trim();

                if (!string.IsNullOrEmpty(studentId))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Check if the student ID exists in the requestidcardids table
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
                            MessageBox.Show("ID card has already been issued for this student.", "Already Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // If status is empty or null, fetch student details
                            string fetchStudentQuery = @"
                        SELECT firstname, department
                        FROM student
                        WHERE id = @studentid
                    ";

                            SqlCommand fetchStudentCommand = new SqlCommand(fetchStudentQuery, connection);
                            fetchStudentCommand.Parameters.AddWithValue("@studentid", studentId);
                            SqlDataReader reader = fetchStudentCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                textBox2.Text = reader["firstname"].ToString(); // Set student name
                                textBox4.Text = reader["department"].ToString(); // Set department
                            }
                            else
                            {
                                MessageBox.Show("Student ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            reader.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Select an Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into pictureBox1
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = textBox1.Text.Trim();
                string name = textBox2.Text.Trim();
                string department = textBox4.Text.Trim();

                if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(department))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Insert values into idcard table
                        string insertQuery = @"
                    INSERT INTO idcard (studentid, name, department)
                    VALUES (@studentid, @name, @department)
                ";

                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@studentid", studentId);
                        insertCommand.Parameters.AddWithValue("@name", name);
                        insertCommand.Parameters.AddWithValue("@department", department);
                        insertCommand.ExecuteNonQuery();

                        // Update status in requestidcardids table
                        string updateQuery = @"
                    UPDATE requestidcardids
                    SET status = 'done'
                    WHERE studentid = @studentid
                ";

                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@studentid", studentId);
                        updateCommand.ExecuteNonQuery();
                        
                        loaddata();

                        //MessageBox.Show("Data inserted into idcard table and status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
