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
    public partial class degreeissuance : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public degreeissuance()
        {
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from requestdegreeids", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if student ID and semester are entered
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                string studentID = textBox1.Text;
                int semester = Convert.ToInt32(textBox2.Text);

                // Check if the semester is 8
                if (semester == 8)
                {
                    // Check if the student ID is in requestdegreeids and status is empty
                    if (IsStudentIDValid(studentID))
                    {
                        // Update status column for the student ID in requestdegreeids table
                        UpdateRequestDegreeStatus(studentID);

                        // Insert into degreestudents table
                        InsertIntoDegreeStudents(studentID);

                        MessageBox.Show("Degree issuance successful!");
                        Admin_panel ap = new Admin_panel();
                        ap.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Student ID not found or status is not empty for semester 8.");
                    }
                }
                else
                {
                    MessageBox.Show("Semester should be 8 for degree issuance.");
                }
            }
            else
            {
                MessageBox.Show("Please enter student ID and semester.");
            }

        }

        // Method to check if the student ID is in requestdegreeids and status is empty
        private bool IsStudentIDValid(string studentID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM requestdegreeids WHERE studentid = @studentID AND status IS NULL", con);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Method to update status column for the student ID in requestdegreeids table
        private void UpdateRequestDegreeStatus(string studentID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE requestdegreeids SET status = 'done' WHERE studentid = @studentID", con);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
            }
        }

        // Method to insert into degreestudents table
        private void InsertIntoDegreeStudents(string studentID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO degreestudents (studentid, name, department) SELECT id, firstname, department FROM student WHERE id = @studentID", con);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
            }
        }



    }
}
