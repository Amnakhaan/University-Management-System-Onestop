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
    public partial class Register_Faculty : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Register_Faculty()
        {
            InitializeComponent();
            grid();
        }
        public void grid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from faculty", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO faculty VALUES (@id, @names, @phone, @password, @gender, @addresses, @department,@course)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.Parameters.AddWithValue("@names", textBox2.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                        cmd.Parameters.AddWithValue("@password", textBox6.Text);
                        cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@addresses", textBox5.Text);
                        cmd.Parameters.AddWithValue("@department", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@course", textBox3.Text);

                        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox6.Text == "")
                        {
                            MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
               // MessageBox.Show("Faculty registered successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from faculty", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE faculty SET id=@id, names=@names, phone=@phone, password=@password, gender=@gender, addresses=@addresses, department=@department,course=@course where id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@names", textBox2.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@password", textBox6.Text);
                    cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@addresses", textBox5.Text);
                    cmd.Parameters.AddWithValue("@department", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@course", textBox3.Text);

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
             }
             MessageBox.Show("Faculty information updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from faculty", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE faculty WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@names", textBox2.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@password", textBox6.Text);
                    cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@addresses", textBox5.Text);
                    cmd.Parameters.AddWithValue("@department", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@course", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            //MessageBox.Show("Faculty deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from faculty", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
