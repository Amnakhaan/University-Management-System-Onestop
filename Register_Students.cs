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
    public partial class Register_Students : Form
    {

        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Register_Students()
        {
            InitializeComponent();
            grid();
        }
        public void grid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from student", conn);
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
                    string query = "INSERT INTO student VALUES (@id, @firstname, @password, @phone, @DOB, @gender, @addresses, @department)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.Parameters.AddWithValue("@firstname", textBox2.Text);
                        cmd.Parameters.AddWithValue("@password", textBox3.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@addresses", textBox5.Text);
                        cmd.Parameters.AddWithValue("@department", comboBox1.Text);

                        if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
                        {
                            MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                //MessageBox.Show("Student registered successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from student", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update student set firstname=@firstname,password=@password, phone=@phone,DOB=@DOB,gender=@gender,addresses=@addresses,department=@department where id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@firstname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", textBox3.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@addresses", textBox5.Text);
                    cmd.Parameters.AddWithValue("@department", comboBox1.Text);

                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
                    {
                        MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Student data updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // show updated data in datagridview
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from student", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete student where id=@id", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@firstname", textBox2.Text);
            cmd.Parameters.AddWithValue("@password", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
            cmd.Parameters.AddWithValue("@addresses", textBox5.Text);
            cmd.Parameters.AddWithValue("@department", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Student information successfully Deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from student", conn);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Register_Students_Load(object sender, EventArgs e)
        {

        }
    }
}
