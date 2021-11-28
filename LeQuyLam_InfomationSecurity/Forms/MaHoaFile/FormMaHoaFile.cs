using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity.Forms
{
    public partial class FormMaHoaFile : Form
    {
        string username,idFile;
        Button btns;
        public FormMaHoaFile(string us)
        {
            InitializeComponent();
            username = us;
        }
        private void LoadTheme()
        {
            label5.ForeColor = ThemeColor.PrimaryColor;
            btTaiLen.BorderColor = ThemeColor.PrimaryColor;
            btGiaiMa.FillColor = ThemeColor.PrimaryColor;
        }
        private void LoadFile()
        {
            string yc = $"[LoadFile]~{username}";
            string ketqua = Result.Instance.Request(yc);
            if (!String.IsNullOrEmpty(ketqua) && !ketqua.Equals("null"))
            {
                List<String> myFile = ketqua.Split('^').ToList();
                //Bóc tách dữ liệu
                // 0 = id, 1 = tên file
                foreach (String item in myFile)
                {
                    Button btn = new Button() { Width = 100, Height = 100 }; //Thêm button vào flowlayout
                    flowLayoutFileList.Controls.Add(btn);
                    string tenfile = item.Split('~')[1];
                    if(tenfile.Length > 20)
                    {
                        tenfile = item.Split('~')[1].Substring(0, 18);
                        tenfile += "****.***";
                    }
                    btn.Text = tenfile;
                    ContextMenuStrip cms = new ContextMenuStrip(); //Thêm contextmenustrip vào button trong flo
                    btn.MouseUp += Btn_MouseUp;
                    btn.Tag = item.Split('~')[0]; //Gán id
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    Guna2Elipse elip = new Guna2Elipse
                    {
                        BorderRadius = 30
                    };
                    elip.SetElipse(btn);
                    //Xử lý màu backgr cho các nhóm quản lý
                    btn.BackColor = ThemeColor.PrimaryColor;
                    cms.Items.Add("Tải về (Tệp đang trong dạng mã hóa)");
                    cms.Items.Add("Xóa/Gỡ File");
                    cms.Items[0].Click += DownFile_Click;
                    cms.Items[1].Click += DelFile_Click;
                    btn.ContextMenuStrip = cms;
                }
            }
        }

        private void DelFile_Click(object sender, EventArgs e)
        {
            //[DelFile]~id File
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xoá file khỏi hệ thống?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var kq = Result.Instance.Request("[DelFile]~" + idFile);
                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Gửi thất bại.");
                }
                else
                {

                    flowLayoutFileList.Controls.Remove(btns);
                    MessageBox.Show("Gửi thất bại.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void DownFile_Click(object sender, EventArgs e)
        {
            //[DownFile]~id File
            //Chọn nơi save
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Tệp tin (*" + ".txt" + ") | *" + ".txt";
            sd.FileName = "123";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sd.FileName, Encoding.UTF8.GetBytes(ndt));
            }
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) //Chuột phải là tùy chọn thu hồi tin nhắn
            {
                idFile = (sender as Button).Tag.ToString();
                btns = sender as Button;
            }
        }

        private void FormChatRieng_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadFile();
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
                #region Chuan bi du lieu de gui
                string makhoa = tbMaKhoa.Text;
                byte[] bMakhoa = Encoding.UTF8.GetBytes(makhoa);
                String tenTep = Path.GetFileName(lbDuongDan.Text);
                tenTep = tenTep.Replace(" ", "_");
                byte[] bNguoigui = Encoding.UTF8.GetBytes(username);

                byte[] bHeader = Encoding.UTF8.GetBytes(tenTep);
                byte[] noiDungTep = File.ReadAllBytes(lbDuongDan.Text);
                byte[] dt = new byte[bNguoigui.Length + 1 + 1 + bMakhoa.Length + 1 + bHeader.Length + noiDungTep.Length];
                dt[0] = (byte)bNguoigui.Length;
                for (int i = 0; i < bNguoigui.Length; i++)
                {
                    dt[i + 1] = bNguoigui[i];
                }
                dt[bNguoigui.Length + 1] = (byte)bMakhoa.Length;
                for (int i = 0; i < bMakhoa.Length; i++)
                {
                    dt[i + 1 + bNguoigui.Length + 1] = bMakhoa[i];
                }
                dt[bMakhoa.Length + 1 + bNguoigui.Length + 1] = (byte)bHeader.Length;
                // Ghep header vào mang byte gui di
                for (int i = 0; i < bHeader.Length; i++)
                {
                    dt[i + 1 + bMakhoa.Length + 1 + bNguoigui.Length + 1] = bHeader[i];
                }
                // Ghep noi dung tep vao mang byte gui di
                for (int i = 0; i < noiDungTep.Length; i++)
                {
                    dt[i + 1 + bMakhoa.Length + 1 + bHeader.Length + bNguoigui.Length + 1] = noiDungTep[i];
                }
                // gui du lieu di
                var kq = Result.Instance.Request(dt);
                #endregion
                if (string.IsNullOrEmpty(kq) && !kq.StartsWith("DONE"))
                {
                    MessageBox.Show("Gửi thất bại. Lỗi đến từ server");
                }
                else
                {
                    Button btn = new Button() { Width = 100, Height = 100 }; //Thêm button vào flowlayout
                    flowLayoutFileList.Controls.Add(btn);
                    string[] arrtenfile = tenTep.Split('.'); ;
                    string tenfile = arrtenfile[0];
                    if (tenfile.Length > 20)
                    {
                        tenfile = tenTep.Substring(0, 18);
                    }
                    tenfile += ".***";
                    btn.Text = tenfile;
                    ContextMenuStrip cms = new ContextMenuStrip(); //Thêm contextmenustrip vào button trong flo
                    btn.MouseUp += Btn_MouseUp;
                    btn.Tag = kq.Split('~')[1];
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    Guna2Elipse elip = new Guna2Elipse
                    {
                        BorderRadius = 30
                    };
                    elip.SetElipse(btn);
                    //Xử lý màu backgr cho các nhóm quản lý
                    btn.BackColor = ThemeColor.PrimaryColor;
                    cms.Items.Add("Tải về (Tệp đang trong dạng mã hóa)");
                    cms.Items.Add("Xóa/Gỡ File");
                    //cms.Items[0].Click += DelGroup_Click;
                    btn.ContextMenuStrip = cms;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng cung cấp đủ thông tin đầu vào!");
            }
        }

        private void btGiaiMa_Click(object sender, EventArgs e)
        {

        }
    }
}
