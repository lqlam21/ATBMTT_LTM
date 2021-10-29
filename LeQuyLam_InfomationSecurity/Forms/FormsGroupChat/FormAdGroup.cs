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
        bool active = false;
        string idmsg;
        int soMember = 0;
        string username, groupname, grouppass;
        string nguoinhancuoi="";
        List<string> listUsMember = new List<string>();
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
        private void FormAdGroup_Load(object sender, EventArgs e)
        {
            tbNoiDung.Focus();
            tbNoiDung.GotFocus += TbNoiDung_GotFocus;
            tbNoiDung.LostFocus += TbNoiDung_LostFocus;
            lbTenNhom.Text = groupname;
            tbMatKhauGr.Text = grouppass;
            pnLichSu.ControlAdded += PnLichSu_ControlAdded;
            cbHideOrShowPass.Checked = true;
            toolTipChangePass.SetToolTip(btChangePassGr, "Nhập mật khẩu mới và nhấn\r\nEnter để đổi mật khẩu nhóm");
            LoadMess();
            LoadMemGr();
        }
        private void btInvaite_Click(object sender, EventArgs e)
        {
            fInvaite formInvaite = new fInvaite(groupname);
            formInvaite.ShowDialog();
        }
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
            string slMember = Result.Instance.Request("[?Member]~" + groupname);
            if (ketqua == "NotInGr" && !String.IsNullOrEmpty(ketqua))
            {
                this.Close();
                MessageBox.Show("Nhóm đã bị xóa");
            }
            else
            {
                if (ketqua != "NULL")
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
                        btn.Tag = dsTinNhan[i];

                        if (i == 0)
                        {
                            if (dsTinNhan[i].Split('~')[3] == nguoinhancuoi)
                            {
                                AddMess(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                            }
                            else
                            {
                                AddMessln(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                                nguoinhancuoi = dsTinNhan[i].Split('~')[3];
                            }
                        }
                        else
                        {
                            if (dsTinNhan[i].Split('~')[3] == nguoinhancuoi)
                            {
                                AddMess(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                            }
                            else
                            {
                                AddMessln(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                                nguoinhancuoi = dsTinNhan[i].Split('~')[3];
                            }
                        }
                    }
                }
                if (!String.IsNullOrEmpty(slMember) && Int32.Parse(slMember) != soMember)
                {
                    DataGridViewsMember.DataSource = null;
                    DataGridViewsMember.Rows.Clear();
                    LoadMemGr();
                }
            }
        }//Tải tin nhắn mới
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
                    groupname + "~" + tbNoiDung.Text.MaHoa();
                string ketqua = Result.Instance.Request(yeucau);
                //"[DONE]~" + gc.Username +"~"+ last_id;
                Guna2Button btn = new Guna2Button() { AutoSize = true };
                btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btn.Tag = tbNoiDung.Text + "~" + ketqua;
                btn.Text = tbNoiDung.Text;
                btn.BorderRadius = 10;
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                ToolTip time = new ToolTip();
                time.SetToolTip(btn, $"Được gửi vào lúc: {DateTime.Now.ToString()}");
                btn.MouseUp += Btn_MouseClick;
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.Items.Add("Thu hồi tin nhắn");
                cms.Items[0].Click += ThuHoiTinNhan_Click;//---------------------
                btn.ContextMenuStrip = cms;
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

        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//Ẩn tin nhắn
            {
               
            }
            else if (e.Button == MouseButtons.Right) //Chuột phải là tùy chọn thu hồi tin nhắn
            {
                idmsg = ((sender as Guna2Button).Tag as string).Split('~')[3];
            }
        }
        private void ThuHoiTinNhan_Click(object sender, EventArgs e)
        {
            //YC: [ThuHoiMess] ~ id ~ count
            string kq = Result.Instance.Request($"[DellMess]~{idmsg}~{soMember}");

            MessageBox.Show($"{soMember}");
        }

        private void lbStt_Click(object sender, EventArgs e)
        {
            tbNoiDung.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btChangePassGr_Click(object sender, EventArgs e)
        {
            tbMatKhauGr.Focus();
        }
        private void DataGridViewsMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DataGridViewsMember.Columns["dc"].Index)
            {
                int id = int.Parse(DataGridViewsMember.Rows[e.RowIndex].Cells["identifier"].Value.ToString()) - 1;
                string us = listUsMember[id];
                //Yc = [KGR] ~ groupname ~ us;
                string yeucau = "[KGR]~" + groupname + "~" + us;
                string ketqua = Result.Instance.Request(yeucau);
                if(ketqua != "DONE" || !string.IsNullOrEmpty(ketqua))
                {
                    DataGridViewsMember.Rows.RemoveAt(id);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
                }
            }
        }//Kick
        private void cbHideOrShowPass_CheckedChanged(object sender, EventArgs e)
        {
            tbMatKhauGr.UseSystemPasswordChar = cbHideOrShowPass.Checked;
        }
        #endregion
        #region Method
        public void LoadMemGr()
        {
            //Yc load thành viên nhóm = [LoadMemGr] ~ username ~ groupname
            //Kq trả về  = username + displayname
            string yeucau = "[LoadMemGr] ~" + username + "~" + groupname;
            string ketqua = Result.Instance.Request(yeucau);
            if (ketqua != "NULL" && !string.IsNullOrEmpty(ketqua))
            {
                List<string> listMember = ketqua.Split('^').ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                int id = 0;
                foreach (string mem in listMember)
                {
                    id++;
                    string[] row = new string[] { id.ToString(), mem.Split('~')[1] };
                    listUsMember.Add(mem.Split('~')[0]);
                    DataGridViewsMember.Rows.Add(row);
                }
                soMember = id;
            }
            else
                soMember = 0;

        }
        public void LoadMess()
        {
            //Yc Gửi tin nhắn = [CheckMIGroup] ~ username ~ groupname
            string ketqua = Result.Instance.Request("[CheckMIGroup]~" + username + "~" + groupname);
            //Trả lời : tên hiển thị + nội dung + time + username người gửi + username người yc
            y = 0;
            if (ketqua != "NULL"&& !string.IsNullOrEmpty(ketqua))
            {
                pnLichSu.Text = "";
                List<String> dsTinNhan = ketqua.Split('^').ToList();
                // dsTinNhan[0].Split('~')[4] -username cuả bản thân ở dạng mã hóa
                for (int i = 0; i < dsTinNhan.Count; i++)
                {
                    pnLichSu.VerticalScroll.Value = pnLichSu.VerticalScroll.Maximum;
                    //dsTinNhan[i].Split('~')[2]; - thời gian gửi
                    //dsTinNhan[i].Split('~')[3] -username người gửi ở dạng mã hóa
                    Guna2Button btn = new Guna2Button() { AutoSize = true };
                    btn.Tag = dsTinNhan[i];
                    
                    if (i == 0) //Xử lý tin nhắn đầu tiên
                    {
                        AddMessFrist(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[0].Split('~')[4]);
                    }
                    else
                    {
                        if (dsTinNhan[i].Split('~')[3] == dsTinNhan[i-1].Split('~')[3]) // cùng 1 người gửi
                        {
                            
                            AddMess(btn,dsTinNhan[i].Split('~')[3], dsTinNhan[0].Split('~')[4]);
                        }
                        else // không cùng 1 người gửi
                        {
                            AddMessln(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[0].Split('~')[4]);
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
        private void Btn_Click(object sender, EventArgs e)
        {
            //Xử lý trạng thái mess
            if ((sender as Guna2Button).Text == ((sender as Guna2Button).Tag as string).Split('~')[2])
                active = true;
            else
                active = false;

            if (active)
                active = false;
            else
            {
                active = true;
            }
            MsgButton(active, (sender as Guna2Button));
        }
        private void MsgButton(bool status,Guna2Button btn)
        {
            Label lbTime = new Label();
            btn.Invoke((MethodInvoker)delegate
            {
                if (status) //Hiển thị thời gian
                {
                    btn.Text = (btn.Tag as string).Split('~')[2]; ;
                    //Xử lý dạng mess( là tnhan gửi hay tnhan nhận)
                    if (btn.Location.X != 5)
                    {
                        int x = pnLichSu.Width - btn.Size.Width - 34;
                        btn.Location = new Point(x, btn.Location.Y);
                    }
                }
                else // Đóng hiển thị thời gian
                {
                    btn.Text = (btn.Tag as string).Split('~')[1];
                    //Xử lý dạng mess( là tnhan gửi hay tnhan nhận)
                    if (btn.Location.X != 5)
                    {
                        int x = pnLichSu.Width - btn.Size.Width - 34;
                        btn.Location = new Point(x, btn.Location.Y);
                    }
                }
            });
        }
        private void AddMessln(Guna2Button btn,string usg, string usn)//Cần thêm các điều kiện
        {
            //Cấu hình button
            Label lb = CauHinhMsgBt(ref btn);
            int x = pnLichSu.Width - btn.Size.Width - 20;
            int y_max = pnLichSu.Height + 5;

            if (y + btn.Size.Height > y_max - 5 && usg == usn)
            //if (y > y_max - 5 && usg == usn)
            {
                btn.CustomizableEdges.BottomRight = false;
                btn.Location = new Point(x - 15, y_max);
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            }
            else if (y + btn.Size.Height > y_max - 5 && usg != usn)
            {
                btn.CustomizableEdges.BottomLeft = false;
                btn.Location = new Point(5, y_max);
                lb.Location = new Point(5, y_max);
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
        private void AddMess(Guna2Button btn , string usg,string usn)
        {
            //Cấu hình button
            CauHinhMsgBt(ref btn);
            y += btn.Size.Height + 5;
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
        private void AddMessFrist(Guna2Button btn,string usgui,string usnhan)
        {
            Label lb = CauHinhMsgBt(ref btn);
            //Cấu hình button

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
        private Label CauHinhMsgBt(ref Guna2Button btn)
        {
            //Cấu hình button
            ToolTip time = new ToolTip();
            time.SetToolTip(btn, $"Được gửi vào lúc: {(btn.Tag as string).Split('~')[2]}");
            btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btn.BorderRadius = 10;
            btn.Text = ((btn.Tag as string).Split('~')[1]).GiaiMa();//Nội dung
            btn.Click += Btn_Click;
            Label lb = new Label() { AutoSize = true };
            lb.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lb.ForeColor = Color.White;
            lb.Text = (btn.Tag as string).Split('~')[0];//Tên hiển thị
            return lb;
            //msg
        }
        #endregion
    }
}
