using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate_Design_UI_Dashboard
{
    public partial class fThemDiem : Form
    {
        public fThemDiem()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)//Save
        {
            string hediem = "";
            float diem;
            if (cbHeDiem.SelectedItem.ToString() == "Điểm quá trình")
            {
                hediem = "DiemTrenLop";
            }
            else if (cbHeDiem.SelectedItem.ToString() == "Điểm giữa kỳ")
            {
                hediem = "DiemThi";
            }
            else if (cbHeDiem.SelectedItem.ToString() == "Điểm cuối kỳ")
            {
                hediem = "DiemThi2";
            }
            DataTable tb = DataProvider.Instance.ExecuteQuery($"SELECT * FROM SinhVien WHERE MSV = N'{tbMSV.Text}'");
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("MSV không hợp lệ");
            }
            else
            {
                if (float.TryParse(tbDiem.Text, out diem))
                {
                    if (diem >= 0 && diem <= 10)
                    {
                        string check = $"SELECT {hediem} FROM Diem WHERE MSV = '{tbMSV.Text}' and MaMon = '{cbMonhoc.SelectedItem}'";
                        DataTable tb2 = DataProvider.Instance.ExecuteQuery(check);
                        //var c = tb2.Rows[0][0].ToString();
                        if (tb2 != null && tb2.Rows.Count > 0)
                        {
                            if (tb2.Rows[0][tb2.Rows.Count - 1].ToString() != "")
                            {
                                MessageBox.Show("Sinh viên đã có điểm. Vui lòng chọn Sửa điểm để Cật nhập điểm cho sinh viên");
                            }
                            else
                            {
                                DataProvider.Instance.ExecuteNonQuery($"UPDATE Diem Set {hediem} = {diem} WHERE MSV = N'{tbMSV.Text}' and MaMon = N'{cbMonhoc.SelectedItem}'");
                                MessageBox.Show("Thêm điểm thành công");
                            }
                        }
                        else
                        {
                            DataProvider.Instance.ExecuteNonQuery($"INSERT INTO Diem(MSV,MaMon,{hediem})" +
                            $" VALUES (N'{tbMSV.Text}',N'{cbMonhoc.SelectedItem}',{diem})");
                            MessageBox.Show("Thêm điểm thành công");
                        }
                        //if (c > 0)
                        //{
                        //    MessageBox.Show("Thêm điểm thành công");
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Điểm phải là số nguyên từ 0-10");
                    }
                }
                else
                {
                    MessageBox.Show("Điểm phải là số nguyên từ 0-10");
                }
            }
        }

        private void fThemDiem_Load(object sender, EventArgs e)
        {
            DataTable tb = DataProvider.Instance.ExecuteQuery($"SELECT MaMon FROM Monhoc");
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                cbMonhoc.Items.Add(tb.Rows[i][0].ToString());
            }
            cbMonhoc.SelectedIndex = 0;
            cbHeDiem.SelectedIndex = 0;
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
