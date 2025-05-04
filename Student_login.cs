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
    public partial class Student_login : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Student_login()
        {
            InitializeComponent();
        }

        private void alog_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Check if the provided facultyid and password match the values in the student table
                string query = "SELECT COUNT(*) FROM student WHERE id = @studentid AND password = @password";
                using (SqlCommand checkCmd = new SqlCommand(query, con))
                {
                    checkCmd.Parameters.AddWithValue("@studentid", textBox1.Text);
                    checkCmd.Parameters.AddWithValue("@password", textBox2.Text);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 1)
                    {
                        //MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Student_panel fp = new Student_panel();
                        fp.Show();
                        this.Hide();

                        // Insert login information into student_login table
                        string insertQuery = "INSERT INTO student_login VALUES (@username, @password, @login_timestamp)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@username", textBox1.Text);
                            cmd.Parameters.AddWithValue("@password", textBox2.Text);
                            cmd.Parameters.AddWithValue("@login_timestamp", dateTimePicker1.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Student ID or Password not recognized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /*using (SqlConnection con = new SqlConnection (connectionString))
        {
            con.Open();
            string query = "INSERT INTO student_login values(@username,@password,@login_timestamp)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@login_timestamp", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
            }
        }*/


    private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void Student_login_Load(object sender, EventArgs e)
        {

        }
    }
}
