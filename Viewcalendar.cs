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
    public partial class Viewcalendar : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Viewcalendar()
        {
            InitializeComponent();
            this.Load += Academic_calendar_Load;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }
        private void Academic_calendar_Load(object sender, EventArgs e)
        {
            //fall
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectQuery = "SELECT * FROM fall;";
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox1.Text = reader["reg"].ToString();
                        textBox2.Text = reader["startclasses"].ToString();
                        textBox3.Text = reader["sess1"].ToString();
                        textBox4.Text = reader["sess2"].ToString();
                        textBox5.Text = reader["endclasses"].ToString();
                        textBox6.Text = reader["finals"].ToString();
                        textBox7.Text = reader["result"].ToString();
                    }
                    reader.Close();
                }

                conn.Close();
            }
            //spring
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectQuery = "SELECT * FROM spring;";
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox8.Text = reader["reg"].ToString();
                        textBox9.Text = reader["startclasses"].ToString();
                        textBox10.Text = reader["sess1"].ToString();
                        textBox11.Text = reader["sess2"].ToString();
                        textBox12.Text = reader["endclasses"].ToString();
                        textBox13.Text = reader["finals"].ToString();
                        textBox14.Text = reader["result"].ToString();
                    }
                    reader.Close();
                }

                conn.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
