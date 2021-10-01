using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity.Forms.FormsGroupChat
{
    public partial class FormAdGroup : Form
    {
        #region Fields
        string username, groupname, grouppass;
        string nguoinhancuoi="";
        int y;//Tọa độ y của bt tin nhắn
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public FormAdGroup(string us, string gn, string gp,string k)
        {
            InitializeComponent();
            username = us;
            groupname = gn;
            grouppass = gp;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        #region Event
        private void FormAdGroup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMaxsize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void timerLoading_Tick(object sender, EventArgs e)
        {
            //Yc load tin nhắn = [NewMessGroup] ~ username ~ groupname
            string ketqua = Result.Instance.Request("[NewMessGroup]~" +username + "~" + groupname);
            if (String.IsNullOrEmpty(ketqua))
            {
                timerLoading.Enabled = false;
                this.Close();
                MessageBox.Show("Máy chủ không phản hồi");
            }
            else if (ketqua != "NULL")
            {
                List<String> dsTinNhan = ketqua.Split('^').ToList();
                for (int i = 0; i < dsTinNhan.Count; i++)
                {
                    pnLichSu.VerticalScroll.Value = pnLichSu.VerticalScroll.Maximum;
                    //dsTinNhan[i].Split('~')[0] - tên hiển thị
                    // [1] - nội dung
                    //dsTinNhan[i].Split('~')[2] - thời gian
                    //dsTinNhan[i].Split('~')[3] - user gửi
                    //dsTinNhan[i].Split('~')[4] - user nhận
                    Guna2Button btn = new Guna2Button() { AutoSize = true };
                    btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    btn.BorderRadius = 10;
                    btn.Text = dsTinNhan[i].Split('~')[1];//Nội dung
                    Label lb = new Label() { AutoSize = true };
                    lb.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    lb.ForeColor = Color.White;
                    lb.Text = dsTinNhan[i].Split('~')[0];
                    if (i == 0)
                    {
                        if (dsTinNhan[i].Split('~')[3] == nguoinhancuoi)
                        {
                            y += btn.Size.Height + 5; //xuống dòng liền không cần chèn tên
                            AddMess(btn,lb, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                        }
                        else
                        {
                            AddMessln(btn, lb, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                            nguoinhancuoi = dsTinNhan[i].Split('~')[3];
                        }
                    }
                    else
                    {
                        if (dsTinNhan[i].Split('~')[3] == nguoinhancuoi)
                        {
                            y += btn.Size.Height + 5; //xuống 
                            AddMess(btn,lb, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                        }
                        else
                        {
                            AddMessln(btn, lb, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                            nguoinhancuoi = dsTinNhan[i].Split('~')[3];
                        }
                    }
                }
            }
        }//Tải tin nhắn mới
        private void FormAdGroup_Load(object sender, EventArgs e)
        {
            tbNoiDung.Focus();
            tbNoiDung.GotFocus += TbNoiDung_GotFocus;
            tbNoiDung.LostFocus += TbNoiDung_LostFocus;
            lbTenNhom.Text = groupname;
            tbMatKhauGr.Text = grouppass;
            pnLichSu.ControlAdded += PnLichSu_ControlAdded;
            LoadMess();
        }
        private void PnLichSu_ControlAdded(object sender, ControlEventArgs e)
        {
            pnLichSu.ScrollControlIntoView(e.Control);
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
        private void tbNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btGui_Click(sender, e);
        }
        private void btGui_Click(object sender, EventArgs e)
        {
            //Yc Gửi tin nhắn = [SendMTGroup] ~ username ~ groupname ~ noidung
            if (tbNoiDung.Text.Trim() == "")
            {
                return;
            }
            else
            {
                string yeucau = "[SendMTGroup]~" + username + "~" +
                    groupname + "~" + tbNoiDung.Text;
                string ketqua = Result.Instance.Request(yeucau);
                Guna2Button btn = new Guna2Button() { AutoSize = true };
                btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btn.Text = tbNoiDung.Text;
                btn.BorderRadius = 10;
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                int x = pnLichSu.Width - btn.Size.Width - 20;
                btn.CustomizableEdges.BottomRight = false;
                int y_max = pnLichSu.Height + 5;//Điểm local max
                if (y + btn.Size.Height > y_max  - 5)
                {
                    btn.Location = new Point(x-15, pnLichSu.Height + 5);
                }
                else
                {
                    y += btn.Size.Height + 5;
                    btn.Location = new Point(x, y);
                }
                if (!ketqua.StartsWith("[DONE]"))
                {
                    Bitmap warning = SystemIcons.Warning.ToBitmap();
                    btn.Image = warning;
                }
                nguoinhancuoi = ketqua.Split('~')[1];
                pnLichSu.VerticalScroll.Value = pnLichSu.VerticalScroll.Maximum;//Sroll Max
                pnLichSu.Controls.Add(btn);
                tbNoiDung.Text = "";
                tbNoiDung.Focus();
            }
        }
        private void lbStt_Click(object sender, EventArgs e)
        {
            tbNoiDung.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Method
        private void LoadMess()
        {
            //Yc Gửi tin nhắn = [CheckMIGroup] ~ username ~ groupname
            string ketqua = Result.Instance.Request("[CheckMIGroup]~" + username + "~" + groupname);
            //Trả lời : tên hiển thị + nội dung + time + username người gửi + username người yc
            y = 0;
            if (ketqua != "NULL"&& !string.IsNullOrEmpty(ketqua))
            {
                pnLichSu.Text = "";
                List<String> dsTinNhan = ketqua.Split('^').ToList();
                // dsTinNhan[0].Split('~')[4] -username cuả mình ở dạng mã hóa
                for (int i=0;i<dsTinNhan.Count;i++)
                {
                    pnLichSu.VerticalScroll.Value = pnLichSu.VerticalScroll.Maximum;
                    //dsTinNhan[i].Split('~')[2]; - thời gian gửi
                    //dsTinNhan[i].Split('~')[3] -username người gửi ở dạng mã hóa
                    Guna2Button btn = new Guna2Button() { AutoSize = true };
                    btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    btn.BorderRadius = 10;
                    btn.Text = dsTinNhan[i].Split('~')[1];//Nội dung
                    Label lb = new Label() { AutoSize = true };
                    lb.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    lb.ForeColor = Color.White;
                    lb.Text = dsTinNhan[i].Split('~')[0];//Tên hiển thị
                    if (i == 0) //Xử lý tin nhắn đầu tiên
                    {
                        AddMessFrist(btn,lb, dsTinNhan[i].Split('~')[3], dsTinNhan[0].Split('~')[4]);
                    }
                    else
                    {
                        if (dsTinNhan[i].Split('~')[3] == dsTinNhan[i-1].Split('~')[3]) // cùng 1 người gửi
                        {
                            y += btn.Size.Height + 5; //xuống 5
                            AddMess(btn, lb,dsTinNhan[i].Split('~')[3], dsTinNhan[0].Split('~')[4]);
                            uimess++;
                        }
                        else // không cùng 1 người gửi
                        {
                            AddMessln(btn, lb, dsTinNhan[i].Split('~')[3], dsTinNhan[0].Split('~')[4]);
                            uimess = 0;
                        }
                    }
                }
                nguoinhancuoi = dsTinNhan[dsTinNhan.Count-1].Split('~')[3];
            }
            else
            {
                pnLichSu.Text = "";
            }
        }//Tải toàn bộ tin nhắn cũ
        private void AddMessln(Guna2Button btn,Label lb,string usg, string usn)//Cần thêm các điều kiện
        {
            int x = pnLichSu.Width - btn.Size.Width - 20;
            int y_max = pnLichSu.Height + 5;

            if (y + btn.Size.Height > y_max - 5 && usg == usn)
            {
                btn.CustomizableEdges.BottomRight = false;
                btn.Location = new Point(x - 15, y_max);
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            }
            else if (y > y_max - 5 && usg != usn)
            {
                int y_lb = y_max;//Tọa độ Y lable
                btn.CustomizableEdges.BottomLeft = false;
                btn.Location = new Point(5, y_max);
                lb.Location = new Point(5, y_lb);
                pnLichSu.Controls.Add(lb);
            }
            else if (y < y_max - 5 && usg == usn)
            {
                y += btn.Size.Height + 5; //xuống 5
                btn.CustomizableEdges.BottomRight = false;
                btn.Location = new Point(x, y);
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            }
            else
            {
                y += btn.Size.Height + lb.Height; //xuống 
                int y_lb = y - btn.Height + 10;//Tọa độ Y lable
                btn.CustomizableEdges.BottomLeft = false;
                btn.Location = new Point(5, y);
                lb.Location = new Point(5, y_lb);
                pnLichSu.Controls.Add(lb);
            }
            pnLichSu.Controls.Add(btn);
        }
        private void AddMess(Guna2Button btn , Label lb, string usg,string usn)
        {
            int x = pnLichSu.Width - btn.Size.Width - 20;
            int y_max = pnLichSu.Height + 5;
            if (y > y_max - 5 && usg != usn)
            {
                btn.Location = new Point(5, y_max);
                btn.CustomizableEdges.BottomLeft = false;
            }
            else if (y > y_max -5 && usg == usn)
            {
                btn.Location = new Point(x-15, y_max);
                btn.CustomizableEdges.BottomRight = false;
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            }
            else if(y < y_max - 5 && usg == usn)
            {
                btn.Location = new Point(x, y);
                btn.CustomizableEdges.BottomRight = false;
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            }
            else
            {
                btn.Location = new Point(5, y);
                btn.CustomizableEdges.BottomLeft = false;
            }
            pnLichSu.Controls.Add(btn);
        }
        private void AddMessFrist(Guna2Button btn,Label lb,string usgui,string usnhan)
        {
            if (usgui != usnhan)
            {
                y = lb.Height-5;
                int y_lb = y - btn.Height + 10;//Tọa độ Y lable
                btn.CustomizableEdges.BottomLeft = false;
                btn.Location = new Point(5, y);
                lb.Location = new Point(5, y_lb);
                pnLichSu.Controls.Add(lb);
            }
            else
            {
                int x = pnLichSu.Width - btn.Size.Width - 20;
                btn.Location = new Point(x, y);
                btn.CustomizableEdges.BottomRight = false;
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            }
            pnLichSu.Controls.Add(btn);
        }
        #endregion
    }
}
