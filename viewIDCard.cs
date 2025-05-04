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
    public partial class viewIDCard : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public viewIDCard()
        {
            InitializeComponent();
            DisplayStudentData();
        }

        private void DisplayStudentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to retrieve the department, student ID, and name from the idcard table
                    // for the recently logged-in student ID
                    string query = @"
                        SELECT department, studentid, name
                        FROM idcard
                        WHERE studentid = (
                            SELECT TOP 1 username
                            FROM student_login
                            ORDER BY login_timestamp DESC
                        )
                    ";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display the department, student ID, and name in textboxes
                        textBox1.Text = reader["department"].ToString(); // Department
                        textBox2.Text = reader["studentid"].ToString(); // Student ID
                        textBox3.Text = reader["name"].ToString(); // Name
                    }
                    else
                    {
                        MessageBox.Show("Student ID not found in idcard table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
