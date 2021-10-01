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
    public partial class FormChatRieng : Form
    {
        public FormChatRieng()
        {
            InitializeComponent();
            tbNoiDung.GotFocus += TbNoiDung_GotFocus;
            tbNoiDung.LostFocus += TbNoiDung_LostFocus;
        }
        private void LoadTheme()
        {
            label4.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void FormChatRieng_Load(object sender, EventArgs e)
        {
            LoadTheme();
            tbNoiDung.Focus();
        }
        private void TbNoiDung_LostFocus(object sender, EventArgs e)
        {
            if (tbNoiDung.Text.Length > 0)
                lbStt.Visible = false;
            else
                lbStt.Visible = true;
        }

        private void TbNoiDung_GotFocus(object sender, EventArgs e)
        {
            lbStt.Visible = false;
        }

        private void lbStt_Click(object sender, EventArgs e)
        {
            tbNoiDung.Focus();
        }
    }
}
