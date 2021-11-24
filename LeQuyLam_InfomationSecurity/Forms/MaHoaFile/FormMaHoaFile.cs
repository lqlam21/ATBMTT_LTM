using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity.Forms
{
    public partial class FormMaHoaFile : Form
    {

        public FormMaHoaFile()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {
            label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void FormChatRieng_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void btChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog
            {
                Multiselect = false
            };
            if (od.ShowDialog() == DialogResult.OK)
            {
                lbDuongDan.Text = od.FileName;
            }
        }

        private void btTaiLen_Click(object sender, EventArgs e)
        {
            if (lbDuongDan.Text.Length >= 3 && tbMaKhoa.Text.Length >0)
            {
                String tenTep = Path.GetFileName(lbDuongDan.Text);
                tenTep = tenTep.Replace(" ", "_");
                String header = "[FILE]" + tenTep;
                byte[] bHeader = Encoding.UTF8.GetBytes(header);
                byte[] noiDungTep = File.ReadAllBytes(lbDuongDan.Text);
                byte[] dt = new byte[1 + bHeader.Length + noiDungTep.Length];
                dt[0] = (byte)bHeader.Length;
                // Ghep header vào mang byte gui di
                for (int i = 0; i < bHeader.Length; i++)
                {
                    dt[i + 1] = bHeader[i];
                }
                // Ghep noi dung tep vao mang byte gui di
                for (int i = 0; i < noiDungTep.Length; i++)
                {
                    dt[i + 1 + bHeader.Length] = noiDungTep[i];
                }
            }
        }

        private void btGiaiMa_Click(object sender, EventArgs e)
        {

        }
    }
}
