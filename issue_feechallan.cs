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
    public partial class issue_feechallan : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public issue_feechallan()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Check if the provided studentid exists in the student table as id
                string checkStudentQuery = "SELECT COUNT(*) FROM student WHERE id = @studentid";
                using (SqlCommand checkStudentCmd = new SqlCommand(checkStudentQuery, con))
                {
                    checkStudentCmd.Parameters.AddWithValue("@studentid", textBox1.Text);
                    int studentCount = (int)checkStudentCmd.ExecuteScalar();
                    if(textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (studentCount == 0)
                    {
                        MessageBox.Show("Student ID does not exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }




            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("insert into feechallan values(@studentid, @semester, @challanno, @amount, @duedate)", con))
                {
                    cmd.Parameters.AddWithValue("studentid",textBox1.Text);
                    cmd.Parameters.AddWithValue("@semester", textBox6.Text);
                    cmd.Parameters.AddWithValue("@challanno", textBox5.Text);
                    cmd.Parameters.AddWithValue("@amount", textBox2.Text);
                    cmd.Parameters.AddWithValue("@duedate", dateTimePicker1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fee Challan Issued Successfully");
                    Admin_panel ap = new Admin_panel();
                    ap.Show();
                    this.Hide();
                }
            }
        }
    }
}
