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
    public partial class fTraDiemcs : Form
    {
        public fTraDiemcs()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)//close
        {
            this.Close();
        }

        private void btLogin_Click(object sender, EventArgs e)//Tra cứu
        {
            DataTable tb = DataProvider.Instance.ExecuteQuery($"EXEC USP_TraDiem2 N'{tbMSV.Text}'");
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu");
                dataGridView1.DataSource = null;
            }
            else
                dataGridView1.DataSource = tb;

        }
    }
}
