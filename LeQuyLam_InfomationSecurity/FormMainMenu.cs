using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity
{
    public partial class FormMainMenu : Form
    {
        #region Fields
        string sHello;

        readonly string key;
        readonly string username;
        private readonly int type;
        private Button currentButton;
        private readonly Random random; //Tạo màu ngẫu nhiên mỗi lần click button
        private int tempIndex;
        private Form activeForm;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam); //Các thao tác sự kiện

        readonly FormMain fMain = new FormMain();
        #endregion

        #region Constructor
        public FormMainMenu(string sUser, string sKey,int nType)
        {
            InitializeComponent();
            type = nType;
            username = sUser;
            key = sKey;
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        #endregion

        #region Method
       
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = sHello;
            panelTitleBar.BackColor = Color.FromArgb(48, 51, 76);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }
        #endregion

        #region Event
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormHome(username,key), sender);
        }

        private void btChatChung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormChat(username,key), sender);
        }

        private void btChatRieng_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormMaHoaFile(username), sender);
        }

        private void btAdmin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormAdmin(), sender);
        }

        private void btGopY_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormGopY(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
 
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaxsize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            sHello = lblTitle.Text;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
