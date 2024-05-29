using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Controls;
using System.Data.Common;

namespace LoginTest
{
    public partial class FormDiary : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Cpe363\\LoginTest\\Database\\db_usersform.mdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataTable dt;
        public FormDiary()
        {
            InitializeComponent();
        }

        void GetUsername()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            dt = new DataTable();
            da = new OleDbDataAdapter("SELECT *FROM tbl_diary",con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private DateTime savedDateTime;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO tbl_diary (username, diary, Saved_datetime) VALUES (@username,@diary,@Saved_datetime)";

                cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txtName.Text); 
                cmd.Parameters.AddWithValue("@diary", textBox1.Text); 
                cmd.Parameters.AddWithValue("@Saved_datetime", dateTimePicker1.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diary has been Saved...");
                GetUsername();
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (int.TryParse(textBox2.Text, out id))
                {
                    string query = "UPDATE tbl_diary SET username = @username, diary = @diary, Saved_datetime = @Saved_datetime WHERE id = @id";

                    cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", txtName.Text);
                    cmd.Parameters.AddWithValue("@diary", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Saved_datetime", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} record has been updated.");
                    GetUsername();
                }
                else
                {
                    MessageBox.Show("Invalid ID. Please check the ID value.");
                }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (int.TryParse(textBox2.Text, out id))
                {
                    string query = "DELETE FROM tbl_diary WHERE id=@id";

                    cmd = new OleDbCommand(query, con);;
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} Diary has been Delete...");
                    GetUsername();
                }
                else
                {
                    MessageBox.Show("Invalid ID. Please check the ID value.");
                }
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

        private void FormDiary_Load(object sender, EventArgs e)
        {
            GetUsername();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }
    }
}
//6401017 Chonchanin nonsurut