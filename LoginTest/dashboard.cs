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

namespace LoginTest
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.panelDesktop.Controls.Count > 0)
                this.panelDesktop.Controls.Clear();
            Form f = (Form)Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(f);
            this.panelDesktop.Tag = f;
            f.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            loadform(new FormDashboard());
        }

        private void btnDiary_Click(object sender, EventArgs e)
        {
            loadform(new FormDiary());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            loadform(new FormCustomers());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            loadform(new FormSetting());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
