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
    public partial class Salary : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Salary()
        {
            InitializeComponent();
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Check if the provided studentid exists in the student table as id
                string checkStudentQuery = "SELECT COUNT(*) FROM faculty WHERE id = @facultyid";
                using (SqlCommand checkStudentCmd = new SqlCommand(checkStudentQuery, con))
                {
                    checkStudentCmd.Parameters.AddWithValue("@facultyid", textBox1.Text);
                    int studentCount = (int)checkStudentCmd.ExecuteScalar();
                    if (studentCount == 0)
                    {
                        MessageBox.Show("Faculty ID does not exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO salary VALUES (@facultyid, @amount, @issuedate, @semester)";
                using (SqlCommand cmd = new SqlCommand(query,con))
                { 
                cmd.Parameters.AddWithValue("@facultyid", textBox1.Text);
                cmd.Parameters.AddWithValue("@amount", textBox6.Text);
                cmd.Parameters.AddWithValue("@issuedate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@semester", comboBox1.Text);

                    if (textBox1.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
                    {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            MessageBox.Show("Salary Generated Successfully");
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();
        }
    }
}
