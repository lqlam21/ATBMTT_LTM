using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity
{
    public partial class FormMain : Form
    {
        #region Fields
        string sCode;// mã xác thực email (random 4 chữ số)
        System.Threading.Thread loadingcode;
        Timer aTimerDelayButton, aTimerCountDown;// tạo ra 2 timer để đếm ngược và tạm vô hiệu hóa button
        string sEmail, sName, sUsername, sKey;
        int nType;
        int nCountDown = 61; // Set thời gian chờ là 61 => khi bắt đầu đếm ngược sẽ đếm từ 60
        int nTimeLate = 61; //Thời gian hiệu lực của code
        //Random rd = new Random();
        public FormMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            aTimerDelayButton = new Timer();
            aTimerCountDown = new Timer();
            aTimerDelayButton.Tick += aTimerDelayButton_Tick;
            aTimerCountDown.Tick += aTimerCountDown_Tick;
        }
        #endregion

        #region Event
        private void pbExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn đóng ứng dụng?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        private void pbMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pbDangKy_Click(object sender, EventArgs e)
        {
            FormDangKy fDangKy = new FormDangKy();
            this.Hide();
            fDangKy.ShowDialog();
            this.Show();
            if (fDangKy.nCheckdk == 1)
            {
                txbUserName.Text = fDangKy.tbID.Text;
                txbPassword.Text = fDangKy.tbPassword.Text;
            }

        }
        private void pbDangNhap_Click(object sender, EventArgs e)
        {
            sUsername = txbUserName.Text;
            //Cấu trúc [DangNhap]~ UserNam ~ Password;
            String yeuCau = "[DangNhap]~" + txbUserName.Text + "~" + txbPassword.Text;
            String ketQua = Result.Instance.Request(yeuCau);
            if (String.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Máy chủ không phản hồi");
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                 sName = ketQua.Split('~')[0];
                 sEmail = ketQua.Split('~')[1];
                 nType = int.Parse(ketQua.Split('~')[2]);
                 sKey = ketQua.Split('~')[3];

                FormMainMenu fTt = new FormMainMenu(sUsername, sKey, nType);
                fTt.lblTitle.Text = "Chào " + sName;
                if (nType == 0) //Tài khoản admin
                {
                    this.Hide();
                    fTt.ShowDialog();
                    this.Show();
                    txbPassword.Text = "";
                    txbUserName.Text = "";
                    txbUserName.Focus();
                }
                else if (nType == 2)//Tài khoản bật bảo vệ 2 lớp
                {
                    SendCode();
                    lbDem.Text = "";
                    lbTimeLate.Text = "";
                    lbEmail.Text = sEmail[0] + "********" + sEmail[sEmail.Length - 11] + "@gmail.com";
                    pnXacMinh.Show();
                    timeCountDownCode.Start();
                }
                else
                {
                    this.Hide();
                    fTt.ShowDialog();
                    this.Show();
                    txbPassword.Text = "";
                    txbUserName.Text = "";
                    txbUserName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thông báo");
            }
        }
        //Event của pnXacNhan
        private void pb_Back_Click(object sender, EventArgs e)
        {
            pnXacMinh.Hide();
        }
        private void btSendAgain_Click(object sender, EventArgs e)
        {
            SendCode();
            btSendAgain.Enabled = false;
            tbCode.Text = "";
            DelayButton(62000);// Set thời gian là 62s để chạy cùng với thời gian đếm ngược (61-0)
            WaitButton();
            nTimeLate = 61;
            timeCountDownCode.Start();
        }
        private void btConfirm_Click(object sender, EventArgs e)
        {
            FormMainMenu fTt = new FormMainMenu(sUsername, sKey, nType);
            if (tbCode.Text == sCode)
            {
                this.Hide();
                tbCode.Text = "";
                pnXacMinh.Hide();
                fTt.lblTitle.Text = sName;
                fTt.ShowDialog();
                this.Show();
                txbPassword.Text = "";
                txbUserName.Text = "";
                txbUserName.Focus();
            }
            else
            {
                MessageBox.Show("Mã xác thực không hợp lệ");
                tbCode.Text = "";
                tbCode.Focus();
                return;
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            pnXacMinh.Hide();
            txbUserName.GotFocus += txbUserName_GotFocus;
            txbUserName.LostFocus += txbUserName_LostFocus;
            txbPassword.GotFocus += txbPassword_GotFocus;
            txbPassword.LostFocus += txbPassword_LostFocus;
        }
        private void txbUserName_LostFocus(object sender, EventArgs e)
        {
            if (txbUserName.Text.Length > 0)
                lbstt1.Visible = false;
            else
                lbstt1.Visible = true;
        }

        private void txbUserName_GotFocus(object sender, EventArgs e)
        {
            lbstt1.Visible = false;
        }

        private void txbPassword_LostFocus(object sender, EventArgs e)
        {
            if (txbPassword.Text.Length > 0)
                lbstt2.Visible = false;
            else
                lbstt2.Visible = true;
        }

        private void txbPassword_GotFocus(object sender, EventArgs e)
        {
            lbstt2.Visible = false;
        }

        private void txbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbPassword.Text.Length > 0)
                    pbDangNhap_Click(sender, e);
                else
                    txbPassword.Focus();
            }    
        }
        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pbDangNhap_Click(sender, e);
        }
        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btConfirm_Click(sender, e);
        }
        #endregion

        #region Method

        void DelayButton(int nInterval)
        {
            aTimerDelayButton.Interval = nInterval;
            aTimerDelayButton.Start();
            btSendAgain.Enabled = false;
        }
        private void aTimerDelayButton_Tick(object sender, EventArgs e)
        {
            btSendAgain.Enabled = true;
            aTimerDelayButton.Stop();
        }
        private void timeCountDownCode_Tick(object sender, EventArgs e)
        {
            nTimeLate--;
            lbTimeLate.Text = "Mã còn hiệu lực trong: " + nTimeLate.ToString() + "s";
            if (nTimeLate == -1) // Set là -1 để label chạy được đến 0 rồi mới kết thúc
            {
                sCode = "codehethieuluc";//Chuyển thành dạng code không thể nhập đúng được(max lenght của tb set là 5)
                lbTimeLate.Text = "Mã đã hết hạn";
                timeCountDownCode.Stop();
                nTimeLate = 61; // Đặt lại thời gian đếm ngược
            }
        }
        void WaitButton()
        {
            aTimerCountDown.Interval = 1000;
            aTimerCountDown.Start();
        }
        private void aTimerCountDown_Tick(object sender, EventArgs e)
        {
            nCountDown--;
            lbDem.Text = "Thử lại sau: " + nCountDown.ToString();
            if (nCountDown == -1) // Set là -1 để label chạy được đến 0 rồi mới kết thúc
            {
                lbDem.Text = "";
                aTimerCountDown.Stop();
                nCountDown = 61; // Đặt lại thời gian đếm ngược
            }
        }//Đếm ngược thời gian chờ button

        private void LoadingCode()
        {
            sCode = Result.Instance.Request("[SendMail]~" + sEmail);
            if (string.IsNullOrEmpty(sCode))
                MessageBox.Show("Máy chủ không phản hồi");
            loadingcode.Abort();
        }
        private void SendCode()
        {
            loadingcode = new System.Threading.Thread(LoadingCode);
            loadingcode.IsBackground = true;
            loadingcode.Start();
        }
        #endregion
    }
}
