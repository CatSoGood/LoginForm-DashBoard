using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LoginTest
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OleDb.4.0;" +
            @"Data Source=D:\Cpe363\LoginTest\Database\db_usersform.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        //6401017 Chonchanin Nonsurut

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtComfirm.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (txtPassword.Text == txtComfirm.Text)
            {
                try
                {
                    con.Open();
                    string register = "INSERT INTO tbl_users (username, [password]) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                    cmd = new OleDbCommand(register, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Success");

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtComfirm.Text = "";
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
            else
            {
                MessageBox.Show("Password does not match, Please try again");
                txtPassword.Text = "";
                txtComfirm.Text = "";
                txtPassword.Focus();
            }
        }

        private void CheckbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComfirm.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComfirm.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComfirm.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }
    }
}
