using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginTest
{
    public partial class FormCustomers : Form
    {
        private OleDbConnection con;
        private OleDbDataAdapter da;
        private DataSet ds;

        public FormCustomers()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Cpe363\\LoginTest\\Database\\db_usersform.mdb");
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "SELECT * FROM tbl_users";
                da = new OleDbDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "tbl_users");
                dataGridView1.DataSource = ds.Tables["tbl_users"];
            }
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
    }
}
