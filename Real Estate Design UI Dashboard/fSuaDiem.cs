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
    public partial class fSuaDiem : Form
    {
        float diemqt,diemgk,diemck;
        string msv="";
        public fSuaDiem()
        {
            InitializeComponent();
        }

        private void btHuy_Click(object sender, EventArgs e)//Close
        {
            this.Close();
        }

        private void btLogin_Click(object sender, EventArgs e)//xem điểm
        {
            //SELECT  FROM Diem 
            LoadingData();
        }
        void LoadingData()
        {
            dataGridView1.DataSource = null;
            DataTable tb = DataProvider.Instance.ExecuteQuery($"EXEC USP_TraDiem3 N'{cbLop.SelectedItem}', N'{cbMonhoc.SelectedItem}'");
            dataGridView1.DataSource = tb;
        }

        private void fSuaDiem_Load(object sender, EventArgs e)
        {
            DataTable tb = DataProvider.Instance.ExecuteQuery($"SELECT MaMon FROM Monhoc");
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                cbMonhoc.Items.Add(tb.Rows[i][0].ToString());
            }
            cbMonhoc.SelectedIndex = 0;
            DataTable tb2 = DataProvider.Instance.ExecuteQuery($"SELECT MaLop FROM Lop");
            for (int i = 0; i < tb2.Rows.Count; i++)
            {
                cbLop.Items.Add(tb2.Rows[i][0].ToString());
            }
            cbLop.SelectedIndex = 0;
        }

        private void guna2Button4_Click(object sender, EventArgs e)//Sửa
        {
            //UPDATE Diem Set 
            if(msv != "")
            {
                if(float.TryParse(tbQtrinh.Text, out diemqt) && float.TryParse(tbGiuaKy.Text, out diemgk) 
                    && float.TryParse(tbCuoiKy.Text, out diemck))
                {
                    if(diemck >=0 && diemck <=10 && diemqt >=0 && diemqt <=10 && diemgk >=0 && diemgk <= 10)
                    {
                        string query = $"UPDATE Diem Set DiemTrenLop = '{tbQtrinh.Text}', DiemThi = '{tbGiuaKy.Text}' , DiemThi2 = '{tbCuoiKy.Text}'" +
                        $" WHERE MSV = '{msv}' and MaMon = '{cbMonhoc.SelectedItem}'";
                        DataProvider.Instance.ExecuteNonQuery(query);
                        LoadingData();
                        MessageBox.Show("Sửa điểm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Điểm phải nhỏ hơn 10 và lớn hơn 0");
                    }
                }
                else
                    MessageBox.Show("Điểm phải là kiểu số nguyên");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                tbQtrinh.Text = row.Cells[2].Value.ToString();
                tbGiuaKy.Text = row.Cells[3].Value.ToString();
                tbCuoiKy.Text = row.Cells[4].Value.ToString();
                msv = row.Cells[0].Value.ToString();
            }
        }
    }
}
