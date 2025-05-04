using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace onestop
{
    public partial class Faculty_login : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Faculty_login()
        {
            InitializeComponent();
        }

        private void alog_Click(object sender, EventArgs e)
        {
            try
            {
                Faculty faculty = new Faculty(connectionString);
                bool loginSuccess = faculty.Login(textBox1.Text, textBox2.Text, dateTimePicker1.Value);

                if (loginSuccess)
                {
                    Faculty_panel fp = new Faculty_panel();
                    fp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Faculty ID or Password not recognized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }
    }

    public class Faculty
    {
        private readonly string connectionString;

        public Faculty(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //oop
        //login class encapsulated in faculty class
        public bool Login(string facultyId, string password, DateTime loginTimestamp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM faculty WHERE id = @facultyid AND password = @password";

                using (SqlCommand checkCmd = new SqlCommand(query, con))
                {
                    checkCmd.Parameters.AddWithValue("@facultyid", facultyId);
                    checkCmd.Parameters.AddWithValue("@password", password);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 1)
                    {
                        // Insert login information into faculty_login table
                        string query1 = "INSERT INTO faculty_login values(@username,@password,@login_timestamp)";
                        using (SqlCommand cmd = new SqlCommand(query1, con))
                        {
                            cmd.Parameters.AddWithValue("@username", facultyId);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@login_timestamp", loginTimestamp);
                            cmd.ExecuteNonQuery();
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
