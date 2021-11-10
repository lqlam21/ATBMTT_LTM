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
    public partial class FormHome : Form
    {
        #region Fields
        private string username,displayname;
        private int type;
        private bool active,activename = false;
        private bool active3, active2 = true;
        private string key;
        #endregion
        //Constructors
        public FormHome(string sUser, string sKey)
        {
            InitializeComponent();
            username = sUser;
            Control.CheckForIllegalCrossThreadCalls = false;
            tbKey.Text = sKey;
        }
        #region Method
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
            //Chưa tìm được cách gộp tất cả các control (cả form cả ở panel nên viết tạm)
            btConfirmChangePass.BackColor = ThemeColor.PrimaryColor;
            btConfirmChangePass.ForeColor = Color.White;
            btConfirmChangePass.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btConfirmSecuritySecond.BackColor = ThemeColor.PrimaryColor;
            btConfirmSecuritySecond.ForeColor = Color.White;
            btConfirmSecuritySecond.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            labelStatus.ForeColor = ThemeColor.SecondaryColor;
            pnBgBot.BackColor = pnBgTop.BackColor = this.BackColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, +0.8);
        }
        private void LoadType()
        {
            //info: [Type] ~ username
            String yeuCau = "[LayDuLieu]~" + username;
            //Mã hóa trước khi gửi
            String ketQua = Result.Instance.Request(yeuCau);
            if (String.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Máy chủ không phản hồi");
            }
            else
            {
            displayname = ketQua.Split('~')[0];
            type = int.Parse(ketQua.Split('~')[2]);
            key = ketQua.Split('~')[3];
            }
        }
        private void ActiveButtonEditName(bool status)
        {
            btEditDisplayname.Invoke((MethodInvoker)delegate
            {
                if (status)
                {
                    tbDisplayname.ReadOnly = false;
                    btEditDisplayname.Text = "Lưu";
                }
                else
                {
                    tbDisplayname.ReadOnly = true;
                    btEditDisplayname.Text = "Sửa";
                    //Đổi tên : [DoiTen] ~ username ~ newname
                    string yeuCau = "[DoiTen]~" + username + "~" + tbDisplayname.Text;
                    string ketQua = Result.Instance.Request(yeuCau);
                    if (string.IsNullOrEmpty(ketQua))
                    {
                        MessageBox.Show("Lỗi máy chủ. Vui lòng thử lại sau");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đổi tên hiển thị thành công");
                        tbDisplayname.Text = displayname;
                        return;
                    }
                }
            });
        }
        private void ActiveButtonKey(bool status)
        {
            btSua.Invoke((MethodInvoker)delegate
            {
            if (status)
            {
                tbKey.ReadOnly = false;
                btSua.Text = "Lưu";
            }
            else
            {
                string yeuCau = "[DoiKey]~"+ username +"~"+ tbKey.Text;
                string ketQua = Result.Instance.Request(yeuCau);
                    if (ketQua == "OK")
                    {
                        MessageBox.Show("Đổi mã khóa thành công");
                        tbKey.Text = key;
                        tbKey.ReadOnly = true;
                        btSua.Text = "Sửa";
                    }
                    else
                    {
                        MessageBox.Show("Lỗi máy chủ. Vui lòng thử lại sau");
                        return;
                    }
                }
            });
        }
        private void ActiveButtonPassWord(bool status)
        {
            btDoiPass.Invoke((MethodInvoker)delegate
            {
                if (status)
                {
                    HideAllPanel();
                }
                else
                {
                    HideAllPanel();
                    panelDoiPass.Show();
                }
            });
        }
        private void ActiveButtonSecuritySecond(bool status)
        {
            btBaoVe.Invoke((MethodInvoker)delegate
            {
                if (status)
                {
                    HideAllPanel();
                }
                else
                {
                    HideAllPanel();
                    panelXacNhan.Show();
                }
            });
        }
        private void CheckStatus()
        {
            if (type == 1)
            {
                labelStatus.Text = "Tài khoản của bạn đang\n\rkhông bật chế độ bảo vệ 2 lớp.";
                btBaoVe.Text = "Bật";
            }
            else if (type == 2)
            {
                labelStatus.Text = "Tài khoản của bạn đang\n\rđược kích hoạt bảo vệ 2 lớp.";
                btBaoVe.Text = "Tắt";
            }
            else
            {
                labelStatus.Text = "Tài khoản admin";
                btBaoVe.Hide();
            }
        }
        private void LoadingUpdateKey()
        {
            MessageBox.Show("Đổi mã khóa thành công");
            tbKey.Text = key;
            tbKey.ReadOnly = true;
            btSua.Text = "Sửa";
        }
        private void HideAllPanel()
        {
            panelXacNhan.Hide();
            panelDoiPass.Hide();
            txbPassWord.Text = "";
            tbOldPass.Text = "";
            tbNewPass.Text = "";
            tbNewPass2.Text = "";
        }
        #endregion
        #region Event
        private void FormHome_Load(object sender, EventArgs e)
        {
            LoadType();
            LoadTheme();
            CheckStatus();
            lbTime.Text = DateTime.Now.ToString("dddd dd MMMM yyyy \n\r               HH:mm:ss");
            lbTime.TextAlign = ContentAlignment.MiddleCenter;
            tbKey.ReadOnly = true;
            tbDisplayname.ReadOnly = true;
            active3 = true; /* Không hiểu tại sao đã khởi tạo active3  = true rồi nhưng vẫn
                            phải để vào Form Load thì điều kiện ở btBaoVe mới = false được */
            HideAllPanel();
            tbKey.Text = key;
            tbDisplayname.Text = displayname;
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (active)
                active = false;
            else
            {
                active = true;
            }
            ActiveButtonKey(active);

        }
        private void timeNow_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("dddd dd MMMM yyyy \n\r               HH:mm:ss");
            key = tbKey.Text;
            displayname = tbDisplayname.Text;
            //Kiểm tra tbKey lớn hơn 6 ký tự mới được phép sửa
            if (tbKey.TextLength > 5 && !tbKey.Text.Contains("^"))
                btSua.Enabled = true;
            else
                btSua.Enabled = false;

            if (tbDisplayname.TextLength > 1 && !tbDisplayname.Text.Contains("~") && !tbDisplayname.Text.Contains("^"))
                btEditDisplayname.Enabled = true;
            else
                btEditDisplayname.Enabled = false;
            //Kiem tra bao ve 2 lop
            CheckStatus();
        }
        private void btBaoVe_Click(object sender, EventArgs e)
        {
            if (active3)
            {
                active3 = false;
                active2 = true;
            }
            else
            {
                active3 = true;
            }
            ActiveButtonSecuritySecond(active3);
        }
        private void btDoiPass_Click(object sender, EventArgs e)
        {
            if (active2)
            {
                active2 = false;
                active3 = true;
            }
            else
            {
                active2 = true;
            }
            ActiveButtonPassWord(active2);
        }

        private void btEditDisplayname_Click(object sender, EventArgs e)
        {
            if (activename)
                activename = false;
            else
            {
                activename = true;
            }
            ActiveButtonEditName(activename);
        }

        private void btConfirmSecuritySecond_Click(object sender, EventArgs e)
        {
            string password = txbPassWord.Text;//Mã hóa lại password
            //Bảo vệ 2 lớp: [UpdateSecondSecurity]~username ~password ~type
            string yeuCau = "[UpdateSecondSecurity]~" + username + "~"
                + password.MaHoa() + "~" + type;
            string ketQua = Result.Instance.Request(yeuCau);
            if (ketQua == "T1")
            {
                MessageBox.Show("Bật thành công!");
                type = 2;
                HideAllPanel();
            }
            else if (ketQua == "T2")
            {
                MessageBox.Show("Tắt thành công!");
                type = 1;
                HideAllPanel();
            }
            else if(ketQua == "WRONG")
            {
                MessageBox.Show("Sai mật khẩu!");
                txbPassWord.Text = "";
                txbPassWord.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Máy chủ không phản hồi!");
                return;
            }
        }

        private void btConfirmChangePass_Click(object sender, EventArgs e)
        {
                                //Đổi pass: [DoiPass]~ username ~ password ~ pass_new
            string old_pass = tbOldPass.Text;
            string new_pas = tbNewPass.Text;
            string yeuCau = "[DoiPass]~" + username + "~" + old_pass.MaHoa() + "~" + new_pas.MaHoa();
            if (tbNewPass.Text == tbNewPass2.Text&&tbNewPass.TextLength>0)
            {
                string ketQua = Result.Instance.Request(yeuCau);
                if (ketQua == "WRONG")
                {
                    MessageBox.Show("Sai mật khẩu!");
                    tbOldPass.Text = "";
                    tbOldPass.Focus();
                    return;
                }
                else if(ketQua == "DONE")
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    HideAllPanel();
                }
                else
                {
                    MessageBox.Show("Máy chủ không phản hồi!");
                    HideAllPanel();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới chưa khớp nhau!");
                tbNewPass.Text = "";
                tbNewPass2.Text = "";
                tbNewPass.Focus();
                return;
            }
        }


        #endregion
    }
}
