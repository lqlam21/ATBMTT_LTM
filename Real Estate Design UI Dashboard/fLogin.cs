using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate_Design_UI_Dashboard
{
    public partial class fLogin : Form
    {
        public bool status = false;
        public fLogin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataTable tb = DataProvider.Instance.ExecuteQuery($"EXEC USP_Login N'{tbUsername.Text}',N'{tbPass.Text}' ");
            if (tb.Rows.Count >= 1)
            {
                status = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản đăng nhập không chính xác");
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
