using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Data.OleDb;

namespace LoginTest
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Cpe363\\LoginTest\\Database\\db_usersform.mdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();

                // 6401017 Chonchanin nonsurut
                string search = "SELECT * FROM tbl_diary WHERE username LIKE ? OR diary LIKE ?";

                cmd = new OleDbCommand(search, con);
                cmd.Parameters.AddWithValue("@username", "%" + txtSearch.Text + "%");
                cmd.Parameters.AddWithValue("@diary", "%" + txtSearch.Text + "%");

                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                dataGridView1.DataSource = dt;            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_usersformDataSet1.tbl_diary' table. You can move, or remove it, as needed.
            

        }
    }
}
