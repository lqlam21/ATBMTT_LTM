using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity.Forms.FormsGroupChat
{
    public partial class FormAdGroup : Form
    {
        #region Fields
        private bool active = false;
        private string idmsg;
        private int soMember = 0;
        private string result_tinnhanMoi, result_tinnhanThuHoi, result_slMem;
        private Stack<Guna2Button> stackMess = new Stack<Guna2Button>();
        private Guna2Button gunabutton;
        Guna2Panel pnChangePass;
        Guna2TextBox tbChangePass;
        private readonly string username;
        private readonly string groupname;
        private readonly string grouppass;

        int y_max;
        private string nguoinhancuoi ="";
        readonly List<string> listUsMember = new List<string>();
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
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        #region Event

        #region form Ev
        private void FormAdGroup_Load(object sender, EventArgs e)
        {
            pnChangePass = new Guna2Panel
            {
                Height = 0,
                Width = 140,
                FillColor = Color.AliceBlue,
                BackColor = Color.FromArgb(61, 61, 86),
                BorderRadius = 10,
                Anchor = (AnchorStyles.Top | AnchorStyles.Right)
            };
            tbChangePass = new Guna2TextBox
            {
                Height = 20,
                Width = 100,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Black,
                FillColor = Color.AliceBlue,
                Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material,
                BackColor = Color.FromArgb(61, 61, 86),
                BorderRadius = 10,
                Anchor = (AnchorStyles.Top | AnchorStyles.Right)
            };
            tbNoiDung.Focus();
            tbNoiDung.GotFocus += TbNoiDung_GotFocus;
            tbNoiDung.LostFocus += TbNoiDung_LostFocus;
            lbTenNhom.Text = groupname;
            tbMatKhauGr.Text = grouppass;
            pnLichSu.ControlAdded += PnLichSu_ControlAdded;
            tbChangePass.KeyUp += TbChangePass_KeyUp;
            cbHideOrShowPass.Checked = true;
            toolTipChangePass.SetToolTip(btChangePassGr, "Nhập mật khẩu mới và nhấn\r\nEnter để đổi mật khẩu nhóm");
            LoadMess("default");
            LoadMemGr();
        }

        private void TbChangePass_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //Yc = [EditPassGr] ~ Username ~ Ten Nhom ~ Mật khẩu mới
                var kq = Result.Instance.Request("[EditPassGr]~"+ username +"~"+ groupname + "~" + tbChangePass.Text.MaHoa());
                if(!string.IsNullOrEmpty(kq) && kq == "DONE")
                {
                    tbMatKhauGr.Text = tbChangePass.Text;
                    MessageBox.Show("Đổi pass nhóm thành công.");
                }
            }
        }
        private void PnLichSu_ControlAdded(object sender, ControlEventArgs e)
        {
            pnLichSu.ScrollControlIntoView(e.Control); //Tự động sroll xuống dưới cùng của tin nhắn
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
        private void cbHideOrShowPass_CheckedChanged(object sender, EventArgs e)
        {
            tbMatKhauGr.UseSystemPasswordChar = cbHideOrShowPass.Checked;
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
        
        private void btInvaite_Click(object sender, EventArgs e)
        {
            fInvaite formInvaite = new fInvaite(groupname);
            formInvaite.ShowDialog();

        }
        private void timerLoading_Tick(object sender, EventArgs e)
        {
            //Yc load tin nhắn = [NewMessGroup] ~ username ~ groupname
            result_tinnhanThuHoi = Result.Instance.Request("[NewMessGroup_Del]~" + username + "~" + groupname);
            if (String.IsNullOrEmpty(result_tinnhanThuHoi))
            {
                timerLoading.Stop();
                MessageBox.Show("Mất kết nối máy chủ");
            }
            else if (result_tinnhanThuHoi == "NotInGr")
            {
                this.Close();
                MessageBox.Show("Nhóm đã bị xóa");
            }
            else
            {
                if (result_tinnhanThuHoi != "NULL"){
                    List<String> dsTinNhan_Del = result_tinnhanThuHoi.Split('^').ToList();
                    foreach (Control btns in pnLichSu.Controls)
                    {
                        if (btns.GetType() == typeof(Guna2Button))
                        {
                            Guna2Button btn = (Guna2Button)btns;
                            if (dsTinNhan_Del.Contains((btn.Tag as string).Split('~')[5]))
                            {
                                DelMess(btn);
                            }
                        }
                    }
                }
            }
            result_tinnhanMoi = Result.Instance.Request("[NewMessGroup]~" +username + "~" + groupname);
            result_slMem = Result.Instance.Request("[?Member]~" + groupname);
            if ( !string.IsNullOrEmpty(result_tinnhanMoi) && result_tinnhanMoi != "NULL")
            {
                List<String> dsTinNhan = result_tinnhanMoi.Split('^').ToList();
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
                    AddMess(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[i].Split('~')[4]);
                    nguoinhancuoi = dsTinNhan[i].Split('~')[3];
                    if ((btn.Tag as string).Split('~')[6] == "Thu Hồi")
                    {
                        DelMess(btn);
                    }
                }
                nguoinhancuoi = dsTinNhan[dsTinNhan.Count - 1].Split('~')[3];
            }
            if (!String.IsNullOrEmpty(result_slMem) && Int32.Parse(result_slMem) != soMember)
            {
                DataGridViewsMember.DataSource = null;
                DataGridViewsMember.Rows.Clear();
                LoadMemGr();
            }

        }//Tải tin nhắn mới
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
                //"[DONE] ~ last_id;
                //------------------------
                Guna2Button btn = new Guna2Button() { AutoSize = true };
                if (string.IsNullOrEmpty(ketqua))//Tin nhắn không được gửi đi
                {
                    Bitmap warning = SystemIcons.Warning.ToBitmap();
                    btn.Image = warning;
                    btn.Tag = "null~" + tbNoiDung.Text.MaHoa() + "~" + DateTime.Now;
                }
                else
                {
                    btn.Tag = "Bạn~" + tbNoiDung.Text.MaHoa() + "~" + DateTime.Now + "~ ~ ~" + ketqua.Split('~')[1];
                }
                AddMess(btn);
                nguoinhancuoi = "you";
                pnLichSu.VerticalScroll.Value = pnLichSu.VerticalScroll.Maximum;//Sroll Max
                pnLichSu.Controls.Add(btn);
                tbNoiDung.Text = "";
                tbNoiDung.Focus();
            }
        }
        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            y_max = pnLichSu.Height + 5;
            if (e.Button == MouseButtons.Left)//Ẩn tin nhắn
            {
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
            else if (e.Button == MouseButtons.Right) //Chuột phải là tùy chọn thu hồi tin nhắn
            {
                gunabutton = (Guna2Button)sender;
            }
        }//action Click mess
        //private void btChangePassGr_Click(object sender, EventArgs e)
        //{
        //    if (actChangePass)
        //    {
        //        actChangePass = false;
        //    }
        //    else
        //    {
        //        actChangePass = true;
        //    }
        //    ActiveBtChangepass(actChangePass,(sender as Guna2Button));
        //}
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
        private void Lb_stt_Click(object sender, EventArgs e)
        {
            pnLichSu.Controls.Clear();
            stackMess.Clear();
            LoadMess("full"); //Tải toàn bộ tin nhắn
        }
        private void DelMess_Click(object sender, EventArgs e)
        {
            idmsg = (gunabutton.Tag as string).Split('~')[5];
            string kq = Result.Instance.Request("[DellMess]~" + idmsg);
            if (!string.IsNullOrEmpty(kq) && kq == "DONE")
                DelMess(gunabutton);
            else
                MessageBox.Show("Đã có lỗi xảy ra từ máy chủ");
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
        public void LoadMess(string stt)
        {
            //Yc Gửi tin nhắn = [CheckMIGroup] ~ username ~ groupname
            //Trả lời : tên hiển thị + nội dung + time + username người gửi + username người yc + id_mess
            string ketqua;
            ketqua = Result.Instance.Request("[CheckMIGroup]~" + username + "~" + groupname + "~" + stt);

            y_max = pnLichSu.Height + 5;
            if (ketqua != "NULL" && !string.IsNullOrEmpty(ketqua))
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
                    if (i > 0)
                    {
                        nguoinhancuoi = dsTinNhan[i-1].Split('~')[3];
                    }
                    else // chưa có người nhắn
                    {
                        nguoinhancuoi = "you";
                    }
                    AddMess(btn, dsTinNhan[i].Split('~')[3], dsTinNhan[0].Split('~')[4]);
                    if ((btn.Tag as string).Split('~')[6] == "Đã Bị Thu Hồi")
                    {
                        DelMess(btn);
                    }
                }
                nguoinhancuoi = dsTinNhan[dsTinNhan.Count-1].Split('~')[3];
                if (dsTinNhan.Count ==10)
                {
                    Label lb_stt = new Label
                    {
                        Text = "Tải thêm tin",
                        Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Underline, GraphicsUnit.Point, ((byte)(0))), // gạch chân
                        Anchor = (AnchorStyles.Top),
                        ForeColor = Color.White,
                        Location = new Point(250, 0)
                    };
                    pnLichSu.Controls.Add(lb_stt);
                    lb_stt.Click += Lb_stt_Click;
                }
                if (nguoinhancuoi == dsTinNhan[0].Split('~')[4])
                {
                    nguoinhancuoi = "you";
                }
            }
            else
            {
                return;
            }
        }//Tải tin nhắn
        //private void ActiveBtChangepass(bool status, Guna2Button btn)
        //{
        //    btn.Invoke((MethodInvoker)delegate
        //    {
        //        if (status)
        //        {
        //            this.Controls.Add(pnChangePass);
        //            pnChangePass.Location = new Point(btChangePassGr.Location.X - 70, btChangePassGr.Location.Y + btChangePassGr.Height + 10);
        //            pnChangePass.BringToFront();
        //            Thread thrd = new Thread(ChangePassShow)
        //            {
        //                IsBackground = true
        //            };
        //            thrd.Start();
        //            tbChangePass.Left = (pnChangePass.Width - tbChangePass.Width) / 2;
        //            tbChangePass.Top = (40 - tbChangePass.Height) / 2;
        //            pnChangePass.Controls.Add(tbChangePass);
        //            tbChangePass.Focus();
        //        }
        //        else 
        //        {
        //            Thread thrd = new Thread(ChangePassHide)
        //            {
        //                IsBackground = true
        //            };
        //            thrd.Start();
        //            tbChangePass.Text = "";
        //        }
        //    });
        //}
        private void ChangePassShow()
        {
            try
            {
                for (int i = 0; i < 40; i++)
                    pnChangePass.Height = i;
            }
            catch
            {
                MessageBox.Show("Thao tác quá nhanh!");
            }

        }
        private void ChangePassHide()
        {
            try
            {
                for (int i = 40; i >= 0; i--)
                    pnChangePass.Height = i;
            }
            catch
            {
                MessageBox.Show("Thao tác quá nhanh!");
            }
        }
        private void MsgButton(bool status,Guna2Button btn)
        {
            Label lbTime = new Label();
            int x =5;
            btn.Invoke((MethodInvoker)delegate
            {
                if (status) //Hiển thị thời gian
                {
                    btn.Text = (btn.Tag as string).Split('~')[2]; ;
                }
                else // Đóng hiển thị thời gian
                {
                    btn.Text = (btn.Tag as string).Split('~')[1].GiaiMa();
                }
                if (btn.Location.X != 5 && y + btn.Height >= y_max)
                {
                    x = pnLichSu.Width - btn.Size.Width - 20;
                }
                else if (btn.Location.X != 5 && y + btn.Height < y_max)
                {
                    x = pnLichSu.Width - btn.Size.Width - 5;
                }
                btn.Location = new Point(x, btn.Location.Y);
            });
        }

        private void timerDellMess_Tick(object sender, EventArgs e)
        {
            foreach (Control btns in pnLichSu.Controls)
            {
                if (btns.GetType() == typeof(Guna2Button))
                {
                    Guna2Button btn = (Guna2Button)btns;
                    var timeCountdownDellMess = DateTime.Now - DateTime.Parse((btn.Tag as string).Split('~')[2]);
                    if (timeCountdownDellMess.Minutes >= 3 && btn.Location.X !=5)
                    {
                        ContextMenuStrip cms = new ContextMenuStrip();
                        btn.ContextMenuStrip = cms;
                        btn.ContextMenuStrip.Dispose();
                    }
                }
            }
        }

        private void btChangePassGr_MouseHover(object sender, EventArgs e)
        {
            this.Controls.Add(pnChangePass);
            pnChangePass.Location = new Point(btChangePassGr.Location.X - 70, btChangePassGr.Location.Y + btChangePassGr.Height + 10);
            pnChangePass.BringToFront();
            Thread thrd = new Thread(ChangePassShow)
            {
                IsBackground = true
            };
            thrd.Start();
            tbChangePass.Left = (pnChangePass.Width - tbChangePass.Width) / 2;
            tbChangePass.Top = (40 - tbChangePass.Height) / 2;
            pnChangePass.Controls.Add(tbChangePass);
            tbChangePass.Focus();
        }

        private void btChangePassGr_MouseLeave(object sender, EventArgs e)
        {
            Thread thrd = new Thread(ChangePassHide)
            {
                IsBackground = true
            };
            thrd.Start();
            tbChangePass.Text = "";
        }

        private void AddMess(Guna2Button btn,string usgui = "you",string usnhan = "you")
        {
            Label lb = CauHinhMsgBt(ref btn);
            //int x = pnLichSu.Width - btn.Size.Width - 20;
            y_max = pnLichSu.Height + 5;
            int y_lb;//Tọa độ Y lable
            int x = pnLichSu.Width - btn.Size.Width - 5;
            if (stackMess.Count == 0 && usgui != usnhan) //Xử lý y đầu tiên, nếu tin nhắn đầu tiên là của bản thân thì y=0
                y = btn.Height;
                //Tin nhắn đầu không phải của bản thân
            else if (stackMess.Count == 0 && usgui == usnhan)
            {
                y = 25;
            }
            else //stackMess khác 0
            {
                if (nguoinhancuoi == usgui)
                    y = (stackMess.Peek()).Location.Y + btn.Height + 5; //Không chèn lb
                    //Đệm 1: y=0, đệm 2: y = y(1)+28 +5 = 33, đệm 3: y = y(3)+ 28 +5 = 46..
                else
                    y = (stackMess.Peek()).Location.Y + btn.Height + lb.Height;//Chèn lb
            }
            if (y + btn.Height - lb.Height >= y_max)
            {
                y = y_max;
                x = pnLichSu.Width - btn.Size.Width - 20;
                y_lb = y_max;
            }
            else
            {
                y_lb = y - btn.Height + 10;//Tọa độ Y lable
            }
            if (usgui != usnhan) // Bên trái khung chat
            {
                if (nguoinhancuoi == usgui)//So sánh người nhắn trước đó và người ngắn cuối
                {
                    //cùng một người thì không cần hiện lb
                    btn.CustomizableEdges.BottomLeft = false;
                    btn.Location = new Point(5, y);
                }
                else //Hiện lb
                {
                    btn.CustomizableEdges.BottomLeft = false;
                    btn.Location = new Point(5, y);
                    lb.Location = new Point(5, y_lb);
                    pnLichSu.Controls.Add(lb);
                }
            }
            else //Tin nhắn của bản thân
            {
                btn.Location = new Point(x, y);
                btn.CustomizableEdges.BottomRight = false;
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                ContextMenuStrip cms = new ContextMenuStrip();
                if ((btn.Tag as string).Split('~')[0] != "null")
                {
                    cms.Items.Add("Thu Hồi");
                    cms.Items[0].Click += DelMess_Click;
                    btn.ContextMenuStrip = cms;
                }
            }
            btn.MouseUp += Btn_MouseClick;
            pnLichSu.Controls.Add(btn);
            stackMess.Push(btn);
        }
        private Label CauHinhMsgBt(ref Guna2Button btn)
        {
            //Cấu hình button
            ToolTip time = new ToolTip();
            string status;
            if ((btn.Tag as string).Split('~')[0] == "null")
            {
                status = "Gửi thất bại";
            }
            else
                status = $"Được gửi vào lúc: {(btn.Tag as string).Split('~')[2]}";
            time.SetToolTip(btn, status);
            btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btn.BorderRadius = 10;
            btn.Text = ((btn.Tag as string).Split('~')[1]).GiaiMa();//Nội dung
            Label lb = new Label() { AutoSize = true };
            lb.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lb.ForeColor = Color.White;
            lb.Text = (btn.Tag as string).Split('~')[0];//Tên hiển thị
            return lb;
            //msg
        }
        private void DelMess(Guna2Button btn)
        {
            btn.FillColor = Color.Gray;
            btn.MouseUp -= Btn_MouseClick;
            ContextMenuStrip cms = new ContextMenuStrip();
            btn.ContextMenuStrip = cms;
            btn.ContextMenuStrip.Dispose();
            btn.Text = "Tin nhắn đã bị thu hồi";
            int x;
            if (btn.Location.X != 5)
            {
                if (y + btn.Height >= y_max)
                {
                    x = pnLichSu.Width - btn.Size.Width - 20;
                }
                else
                    x = pnLichSu.Width - btn.Width - 5;
            }
            else
                x = 5;
            btn.Location = new Point(x, btn.Location.Y);
            btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
        }

        #endregion
    }
}
