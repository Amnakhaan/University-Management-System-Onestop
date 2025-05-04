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
    public partial class viewdegree : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public viewdegree()
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
                        FROM degreestudents
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
                        textBox2.Text = reader["department"].ToString(); // Department
                        textBox1.Text = reader["name"].ToString(); // Name
                 
                        textBox2.Font = new Font(textBox2.Font, FontStyle.Bold);
                        textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
                    }
                    else
                    {
                        MessageBox.Show("Student ID not found in degreestudents table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
