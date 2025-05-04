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
    public partial class Academic_calendar : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Academic_calendar()
        {
            InitializeComponent();
            this.Load += Academic_calendar_Load;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.Show();
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


        private void button2_Click(object sender, EventArgs e)
        {
            //update
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //fall
                string updateQuery = "UPDATE fall SET reg=@reg, startclasses=@startclasses, sess1=@sess1, sess2=@sess2, endclasses=@endclasses, finals=@finals, result=@result;";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@reg", textBox1.Text);
                    cmd.Parameters.AddWithValue("@startclasses", textBox2.Text);
                    cmd.Parameters.AddWithValue("@sess1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@sess2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@endclasses", textBox5.Text);
                    cmd.Parameters.AddWithValue("@finals", textBox6.Text);
                    cmd.Parameters.AddWithValue("@result", textBox7.Text);
                    if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                    {
                        MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }   
                    cmd.ExecuteNonQuery();
                }

                //spring
                string updateQuery2 = "UPDATE spring SET reg=@reg, startclasses=@startclasses, sess1=@sess1, sess2=@sess2, endclasses=@endclasses, finals=@finals, result=@result;";
                using (SqlCommand cmd = new SqlCommand(updateQuery2, con))
                {
                    cmd.Parameters.AddWithValue("@reg", textBox8.Text);
                    cmd.Parameters.AddWithValue("@startclasses", textBox9.Text);
                    cmd.Parameters.AddWithValue("@sess1", textBox10.Text);
                    cmd.Parameters.AddWithValue("@sess2", textBox11.Text);
                    cmd.Parameters.AddWithValue("@endclasses", textBox12.Text);
                    cmd.Parameters.AddWithValue("@finals", textBox13.Text);
                    cmd.Parameters.AddWithValue("@result", textBox14.Text);
                    if(textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "")
                    {
                        MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }  
            MessageBox.Show("Academic Calendar updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            
            // redirect to admin panel form
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();

        }

    }
}
