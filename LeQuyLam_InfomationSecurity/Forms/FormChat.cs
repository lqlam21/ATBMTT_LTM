using Guna.UI2.WinForms;
using LeQuyLam_InfomationSecurity.Forms.FormsGroupChat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity.Forms
{
    public partial class FormChat : Form
    {
        #region Field
        string username,sTenNhom,key;
        int soluongGroup = 0;
        List<string> lsGroup = new List<string>();
        #endregion
        public FormChat(string us,string k)
        {
            key = k;
            username = us;
            InitializeComponent();
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
            label4.ForeColor = ThemeColor.SecondaryColor;
            this.BackColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor,+ 0.8);
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("Tạo nhóm");
            cms.Items[0].Click += btTaoNhom_Click;
            cms.Items.Add("Tìm nhóm");
            cms.Items[1].Click += btSearch_Click;
            flowLayoutNhomChat.ContextMenuStrip = cms;
        }
        private void LoadingGroup()
        {
            flowLayoutNhomChat.Controls.Clear();
            LoadGroup(username);
        }        
        private void LoadGroup(string us)
        {
            //Yc = [MyGroup] ~ username
            string yeucau = "[LoadGroup]~" + us;
            string ketqua = Result.Instance.Request(yeucau);
            if (!String.IsNullOrEmpty(ketqua) && !ketqua.Equals("[NULL]"))
            {
                List<String> mygr = ketqua.Split('^').ToList();
                //Bóc tách dữ liệu
                lsGroup.Clear();
                int id = 0;
                foreach (String item in mygr)
                {
                    id++;
                    string tennhom = item.Split('~')[0].ToString();
                    lsGroup.Add(tennhom);//Gán tên nhóm vào list
                    Button btn = new Button() { Width = 100, Height = 100 }; //Thêm button vào flowlayout
                    flowLayoutNhomChat.Controls.Add(btn);
                    ContextMenuStrip cms = new ContextMenuStrip(); //Thêm contextmenustrip vào button trong flo
                    btn.MouseUp += Btn_MouseClick;
                    btn.Tag = item; //Gán tag
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    Guna2Elipse elip = new Guna2Elipse();
                    elip.BorderRadius = 30;
                    elip.SetElipse(btn);
                    //Xử lý màu backgr cho các nhóm quản lý
                    if (item.Split('~')[2].ToString() == "truongnhom")
                    {
                        btn.BackColor = Color.LightPink;
                        btn.Text = tennhom + "\n\r(Nhóm của bạn)";
                        cms.Items.Add("Xóa nhóm");
                        cms.Items[0].Click += DelGroup_Click;
                        btn.ContextMenuStrip = cms;
                        toolTipGroup.SetToolTip(btn, "Nhấn chuột phải để chọn xóa nhóm");
                    }//Xử lý khi nhóm chat do user lập
                    else
                    {
                        btn.BackColor = Color.LightBlue;
                        btn.Text = tennhom;
                        cms.Items.Add("Rời nhóm");
                        btn.ContextMenuStrip = cms;
                        cms.Items[0].Click += OutGroup_Click;
                        toolTipGroup.SetToolTip(btn, "Nhấn chuột phải để chọn rời nhóm");
                    }//Xử lý khi nhóm chat user đó là thành viên
                }
                soluongGroup = id;
                lbStt.Text = "";
            }
            else
                soluongGroup = 0;
        }
        #endregion

        #region Event
        private void DelGroup_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Nhóm sau khi xóa sẽ không thể phục hồi", "Cảnh báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Yêu cầu xóa: [DelGr] ~ tên nhóm
                string yeucau = "[DelGr]~" + sTenNhom;
                string ketqua = Result.Instance.Request(yeucau);
            }
            else
            {
                return;
            }
        }
        private void OutGroup_Click(object sender, EventArgs e)
        {
            //Yêu cầu rời: [OutGr] ~ tên nhóm
            string yeucau = "[OutGr]~" + sTenNhom + "~" + username;
            string ketqua = Result.Instance.Request(yeucau);
        }
        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            string namegr = ((sender as Button).Tag as string).Split('~')[0];//Lấy tên nhóm(Tên nhóm đang trong dạng mã hóa)
            string chucvu = ((sender as Button).Tag as string).Split('~')[2];
            //Nếu là trưởng nhóm thì sẽ trả về passnhom còn nếu là thành viên thì sẽ trả về là key mã hóa chung
            if (e.Button == MouseButtons.Left)//Chuột trái là truy cập vào nhóm
            {
                if (chucvu == "truongnhom")
                {
                    string passnhom = ((sender as Button).Tag as string).Split('~')[3];
                    FormAdGroup groupAd = new FormAdGroup(username, namegr, passnhom,key);
                        groupAd.Show();
                }
                else
                {
                    string keynhom = ((sender as Button).Tag as string).Split('~')[3];
                    FormMemberGroup groupMem = new FormMemberGroup(username, namegr);
                    groupMem.Show();
                }
            }
            else if (e.Button == MouseButtons.Right) //Chuột phải là xóa hoặc rời nhóm
            {
                sTenNhom = namegr;
            }
        }//Mở nhóm
        private bool CheckGroup(string grname, List<string>lsG)
        {
            int check = 0;
            foreach(string item in lsG)
            {
                if (grname == item)//Nếu tên nhóm đã có trong list
                    check++;
            }
            if (check > 0)//Tên nhóm có trong list
                return true;
            else
                return false;
        }//Kiểm tra bạn đã trong nhóm hay chưa

        private void timerLoadGr_Tick(object sender, EventArgs e)
        {
            //Yc = [?Gr] ~ username
            string ketqua = Result.Instance.Request("[?Gr]~" + username);
            if (string.IsNullOrEmpty(ketqua))
            {
                this.Close();
                MessageBox.Show("Mất kết nối máy chủ");
            }
            else if(Int32.Parse(ketqua) != soluongGroup) //Có xảy ra cập nhật
            {
                LoadingGroup();
            }
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadingGroup();
            timerLoadGr.Start();
        }
        private void btTaoNhom_Click(object sender, EventArgs e)
        {
            //Yc = [TaoNhom] ~ username ~ tên nhóm ~ mật khậu nhóm
            string groupname = tbTenNhom.Text.Trim();
            string grouppass = tbMatKhau.Text.Trim();
            if (groupname == "" || grouppass == "")
            {
                MessageBox.Show("Bạn không được để trống tên và mật khẩu nhóm.");
                tbTenNhom.Focus();
            }
            else if (groupname.Contains("~") || groupname.Contains("^"))
            {
                MessageBox.Show("Tên nhóm chứa ký tự cấm sử dụng");
                tbTenNhom.Focus();
            }
            else
            {
                string yeucau = "[TaoNhom]~" + username +
                    "~" + groupname + 
                    "~" + grouppass.MaHoa();
                string ketqua = Result.Instance.Request(yeucau);
                if (ketqua == "DTT")
                {
                    MessageBox.Show("Nhóm đã tồn tại.");
                    tbTenNhom.Text = "";
                    tbMatKhau.Text = "";
                    tbTenNhom.Focus();
                    return;
                }
                else if (ketqua == "TC")
                {
                    MessageBox.Show("Tạo thành công.");
                    tbTenNhom.Text = "";
                    tbMatKhau.Text = "";
                }
                else
                {
                    MessageBox.Show("Mất kết nối, vui lòng thử lại");
                    return;
                }
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            //Yc = [TimNhom] ~ username ~ tên nhóm ~ mật khậu nhóm
            string groupname = tbTenNhom.Text.Trim();
            string grouppass = tbMatKhau.Text.Trim().MaHoa();
            if (groupname == "" || grouppass == "")
            {
                MessageBox.Show("Bạn không được để trống tên và mật khẩu nhóm.");
                tbTenNhom.Focus();
            }
            else if (CheckGroup(groupname,lsGroup))
            {
                MessageBox.Show("Bạn đã ở trong nhóm.");
                return;
            }
            else
            {
                string yeucau = "[TimNhom]~" + username +
                    "~" + groupname +
                    "~" + grouppass;
                string ketqua = Result.Instance.Request(yeucau);
                if (ketqua == "KTT")
                {
                    MessageBox.Show("Sai mật khẩu hoặc tên nhóm không tồn tại.");
                    tbTenNhom.Text = "";
                    tbMatKhau.Text = "";
                    tbTenNhom.Focus();
                    return;
                }
                if (ketqua == "BLOCK")
                {
                    MessageBox.Show("Hiện tại bạn chỉ có thể tham gia nhóm khi được Host mời.","Bạn bị kick khỏi nhóm");
                    tbTenNhom.Text = "";
                    tbMatKhau.Text = "";
                    tbTenNhom.Focus();
                    return;
                }
                else if (ketqua == "TC")
                {
                    MessageBox.Show("Tham gia thành công.");
                    tbTenNhom.Text = "";
                    tbMatKhau.Text = "";
                }
                else
                {
                    MessageBox.Show("Mất kết nối, vui lòng thử lại");
                    return;
                }
            }
        }
        #endregion
    }
}
