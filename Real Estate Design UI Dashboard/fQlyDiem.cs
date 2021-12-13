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
    public partial class fQlyDiem : Form
    {
        private Form activeForm;
        public fQlyDiem()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)//Xem điểm
        {
            if (activeForm != null)
                activeForm.Close();
            dataGridView1.DataSource = null;
            DataTable tb = DataProvider.Instance.ExecuteQuery($"EXEC USP_TraDiemLop N'{tbMaLop.Text}'");
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu");
                dataGridView1.DataSource = null;
            }
            else
                dataGridView1.DataSource = tb;
        }

        private void btLogin_Click(object sender, EventArgs e)//Môn quản lý
        {
            if (activeForm != null)
                activeForm.Close();
            dataGridView1.DataSource = null;
            DataTable tb = DataProvider.Instance.ExecuteQuery($"SELECT MaMon, TenMon FROM MonHoc");
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu");
                dataGridView1.DataSource = null;
            }
            else
                dataGridView1.DataSource = tb;
        }

        private void btADD_Click(object sender, EventArgs e)//Them
        {
            dataGridView1.DataSource = null;
            OpenChildForm(new fThemDiem());
            //pnAdd.Show();
        }

        private void fQlyDiem_Load(object sender, EventArgs e)
        {

        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnAdd.Controls.Add(childForm);
            this.pnAdd.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)//Sửa
        {
            OpenChildForm(new fSuaDiem());
        }
    }
}
