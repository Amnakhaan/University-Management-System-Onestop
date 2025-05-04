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
    public partial class viewchallan : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-RVBLP7G\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;";

        public viewchallan()
        {
            InitializeComponent();
            LoadChallanData();
        }

        private void LoadChallanData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to retrieve fee challan information
                    string query = @"
                        SELECT fc.semester, fc.challanno, fc.amount, fc.duedate
                        FROM feechallan fc
                        WHERE fc.studentid = (
                            SELECT TOP 1 username
                            FROM student_login
                            ORDER BY login_timestamp DESC
                        )
                        ORDER BY fc.semester DESC, fc.challanno DESC;
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
            Student_panel sp = new Student_panel();
            sp.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This event is not handled in this example
        }
    }
}
