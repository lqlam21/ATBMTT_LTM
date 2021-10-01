using System;
using System.Data;
using System.Windows.Forms;


namespace LeQuyLam_InfomationSecurity
{
    public partial class FormDangKy : Form
    {
        #region Fields
        System.Threading.Thread loadingcode;
        public int nCheckdk = 0;//Điều kiện để thực thi lệnh Đăng nhập ngay
        string sCode;//Mã xác thực email (random 4 chữ số)
        int nCountDown = 61; // Set thời gian chờ là 61 => khi bắt đầu đếm ngược sẽ đếm từ 60
        int nTimeLate = 61;//Thời gian hiệu lực của code
        Timer aTimerDelayButton,aTimerCountDown;// tạo ra 2 timer để đếm ngược và tạm vô hiệu hóa button
        public FormDangKy()
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
            this.Close();
        }

        private void pbDangky_Click(object sender, EventArgs e)
        {
            #region Kiểm tra đầu vào
            //Cấu trúc kiểm tra tài khoản: [KiemTraTaiKhoan] ~ username
            string yeuCau = "[KiemTraTaiKhoan]~" + tbID.Text;
            string ketQua = Result.Instance.Request(yeuCau);
            if (tbDisplayName.Text.Trim() == ""||tbID.Text.Trim()==""||tbPassword.Text.Trim()=="")
            {
                MessageBox.Show("Không trống thông tin!");
            }
            else if (tbPassword.Text != tbNhapLaiPass.Text)
            {
                MessageBox.Show("Mật khẩu không giống nhau");
                tbPassword.Focus();
                tbPassword.Text = "";
                tbNhapLaiPass.Text = "";
            }
            else if (ketQua=="DTT")
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại");
                tbID.Text = "";
                tbID.Focus();
            }
            else if (!IsValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Địa chỉ Email không hợp lệ");
                tbEmail.Text = "";
                tbEmail.Focus();
            }
            else // Hợp lệ
            {
                SendCode();
                // gui email
                pnNhapCode.Show();
                timeCountdownCode.Start();
            }
        }
        #endregion
        private void FormDangKy_Load(object sender, EventArgs e)
        {
            pnNhapCode.Hide();
            lbDemNguoc.Text = "";
            lbTimeLate.Text = "";
        }

        //Event của pnXacNhan
        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (tbCode.Text == sCode)
            {
                //Đăng ký: [DangKy] ~ DisPlayName ~ Key ~ Pass ~ Email ~ Username
                string sKey = tbID.Text + sCode;
                string sPassword = tbNhapLaiPass.Text.Trim();
                string sEmail = tbEmail.Text.Trim();
                string sUsername = tbID.Text.Trim();
                //Mã hóa trước khi gửi cho sever
                string yeuCau = "[DangKy]~" + tbDisplayName.Text + "~" + sKey + "~" + sPassword + "~" + sEmail + "~" + sUsername;
                string ketQua = Result.Instance.Request(yeuCau);
                if (String.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Máy chủ không phản hồi");
                }
                else if (ketQua == "OK") 
                {
                    pnNhapCode.Hide();
                    DialogResult dialogResult = MessageBox.Show("Đăng ký thành công. Đăng nhập ngay?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        nCheckdk = 1; //Check == 1 thì đăng nhập sẽ tự động nhận id và password
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Mã xác thực không hợp lệ");
                tbCode.Focus();
                return;
            }
        }

        private void btSendAgain_Click(object sender, EventArgs e)
        {
            nTimeLate = 61;
            btSendAgain.Enabled = false;
            SendCode();
            tbCode.Text = "";
            tbCode.Focus();
            DelayButton(62000);// Set thời gian là 62s để chạy cùng với thời gian đếm ngược (61-0)
            WaitButton();
            timeCountdownCode.Start();
        }

        private void pb_Back_Click(object sender, EventArgs e)
        {
            pnNhapCode.Hide();
            tbCode.Text = "";// Xóa bỏ text ở label
        }
        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btConfirm_Click(sender, e);

        }

        private void tbID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbDisplayName.Focus();
        }

        private void tbDisplayName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbPassword.Focus();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbNhapLaiPass.Focus();
        }

        private void tbNhapLaiPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbEmail.Focus();
        }

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pbDangky_Click(sender, e);
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
        void WaitButton()
        {
            aTimerCountDown.Interval = 1000;
            aTimerCountDown.Start();
        }
        private bool IsValidEmail(string email) // Kiểm tra địa chỉ email
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void LoadingCode()
        {
            sCode = Result.Instance.Request("[SendMail]~" + tbEmail.Text);
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
        private void timeCountdownCode_Tick(object sender, EventArgs e)
        {
            nTimeLate--;
            lbTimeLate.Text = "Mã còn hiệu lực trong: " + nTimeLate.ToString() + "s";
            if (nTimeLate == -1) // Set là -1 để label chạy được đến 0 rồi mới kết thúc
            {
                sCode = "code het hieu luc";//Chuyển mã Code sang số không thể nhập đúng được(max lenght của tb set là 5 nên k thể nhập 11111111)
                lbTimeLate.Text = "Mã hết hạn";
                timeCountdownCode.Stop();
                nTimeLate = 61; // Đặt lại thời gian đếm ngược
            }
        }

        private void aTimerCountDown_Tick(object sender, EventArgs e)
        {
            nCountDown--;
            lbDemNguoc.Text = "Thử lại sau: "+ nCountDown.ToString();
            if (nCountDown == -1) // Set là -1 để label chạy được đến 0 rồi mới kết thúc
            {
                lbDemNguoc.Text = "";
                aTimerCountDown.Stop();
                nCountDown = 61; // Đặt lại thời gian đếm ngược
            }
        }
        #endregion
    }
}
