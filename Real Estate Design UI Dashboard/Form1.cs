using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate_Design_UI_Dashboard
{
    public partial class Form1 : Form
    {
        bool status = false;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button14_Click(object sender, EventArgs e) // Login
        {
            //DataTable tb= DataProvider.Instance.ExecuteQuery($"EXEC USP_Login N'{tbUsername.Text}',N'{tbPassword.Text}' ");
            //if (tb.Rows.Count >= 1)
            //{
            //    pbLogin.Hide();
            //    btLogin.Text = "Đăng xuất";
            //    status = true;
            //    MessageBox.Show("Đăng nhập thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Tài khoản đăng nhập không chính xác");
            //}
            fLogin flog = new fLogin();
            this.Hide();
            flog.ShowDialog();
            status = flog.status;
            if (flog.status)
            {
                pbLogin.Hide();
                btLogin.Text = "Đăng xuất";
            }
            else
            {
                pbLogin.Show();
                btLogin.Text = "Đăng nhập";
            }
            this.Show();
        }
    

        private void guna2Button2_Click(object sender, EventArgs e)//Quản lý điểm
        {
            if (status)
            {
                OpenChildForm(new fQlyDiem());
            }
            else
            {
                MessageBox.Show("Bạn cần phải đăng nhập để sử dụng chức năng này");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)//Tra điểm
        {
            fTraDiemcs f1 = new fTraDiemcs();
            f1.Show();
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(childForm);
            this.pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)//Trang chủ
        {
            if (activeForm != null)
                activeForm.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)//Môn
        {
            if (status)
            {
                //OpenChildForm(new fQlyDiem());
            }
            else
            {
                MessageBox.Show("Bạn cần phải đăng nhập để sử dụng chức năng này");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (status)
            {
                //(new fQlyDiem());
            }
            else
            {
                MessageBox.Show("Bạn cần phải đăng nhập để sử dụng chức năng này");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)//Qly sv
        {
            if (status)
            {
                //OpenChildForm(new fQlyDiem());
            }
            else
            {
                MessageBox.Show("Bạn cần phải đăng nhập để sử dụng chức năng này");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (status)
            {
                //OpenChildForm(new fQlyDiem());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này");
            }
        }
    }
}
