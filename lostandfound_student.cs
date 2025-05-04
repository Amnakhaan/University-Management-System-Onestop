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
    public partial class lostandfound_student : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public lostandfound_student()
        {
            InitializeComponent();
            grid();
        }
        public void grid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select itemid,itemname from lostfound", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get the itemid and other data entered by the user
                int itemId = Convert.ToInt32(textBox1.Text); // Assuming textBoxItemId is the textbox for itemid
                string itemName = textBox2.Text; // Assuming textBoxItemName is the textbox for itemname
                string location = textBox3.Text; // Assuming textBoxLocation is the textbox for location
                string time = comboBox1.Text; // Assuming textBoxTime is the textbox for time

                // Execute the query to check for a match
                string query = @"SELECT COUNT(*) FROM lostfound 
                     WHERE itemid = @ItemId 
                     AND itemname = @ItemName 
                     AND location = @Location 
                     AND time = @Time;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
                command.Parameters.AddWithValue("@ItemName", itemName);
                command.Parameters.AddWithValue("@Location", location);
                command.Parameters.AddWithValue("@Time", time);

                int rowCount = (int)command.ExecuteScalar();

                if (rowCount > 0)
                {
                    MessageBox.Show("You successfully claimed your belonging. You can collect it from One Stop.");
                    // Delete the claimed item from the lostfound table
                    string deleteQuery = @"DELETE FROM lostfound 
                               WHERE itemid = @ItemId 
                               AND itemname = @ItemName 
                               AND location = @Location 
                               AND time = @Time;";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@ItemId", itemId);
                    deleteCommand.Parameters.AddWithValue("@ItemName", itemName);
                    deleteCommand.Parameters.AddWithValue("@Location", location);
                    deleteCommand.Parameters.AddWithValue("@Time", time);
                    deleteCommand.ExecuteNonQuery();

                    grid();
                }
                else
                {
                    // No matching row found
                    MessageBox.Show("Your claim is false.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }
    }
}
