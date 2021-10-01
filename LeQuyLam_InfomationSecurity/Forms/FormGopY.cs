using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity.Forms
{
    public partial class FormGopY : Form
    {

        public FormGopY()
        {
            InitializeComponent();

        }
        string danhgia;
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label4.ForeColor = ThemeColor.SecondaryColor;
        }

        private void FormGopY_Load(object sender, EventArgs e)
        {
            tbYKien.Focus();
            rbT.Checked = true;
            LoadTheme();
        }
        private void DanhGia()
        {
            if (rbCT.Checked)
                danhgia = rbCT.Text;
            else if (rbKHL.Checked)
                danhgia = rbKHL.Text;
            else if (rbRT.Checked)
                danhgia = rbRT.Text;
            else 
                danhgia = rbKHL.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DanhGia();
            if (tbYKien.TextLength > 0)
            {
                //info: [GopY] ~ danhgia ~ ykien
                string yeuCau = "[GopY]~" + danhgia + "~" + tbYKien.Text;
                
                if(Result.Instance.Request(yeuCau)=="DONE")
                    MessageBox.Show("Ý kiến của bạn đã được gửi đi.\n\rCảm ơn bạn đã góp ý cho tôi.");
                else
                    MessageBox.Show("Mất kết nối server!.Vui lòng thử lại sau");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ý kiến của bạn trước khi gửi.");
                return;
            }
        }
    }
}
