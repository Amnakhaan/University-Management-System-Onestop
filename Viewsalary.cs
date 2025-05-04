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
    public partial class Viewsalary : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public Viewsalary()
        {
            InitializeComponent();
            loadSalaryData();
        }
        private void loadSalaryData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to retrieve salary information
                    string query = @"
                        SELECT issuedate,amount,semester
                        FROM salary
                        WHERE facultyid = (
                            SELECT TOP 1 username
                            FROM faculty_login
                            ORDER BY login_timestamp DESC
                        )
                        ORDER BY issuedate DESC;
                    ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Faculty_panel fp = new Faculty_panel();
            fp.Show();
            this.Hide();
        }
    }
}
