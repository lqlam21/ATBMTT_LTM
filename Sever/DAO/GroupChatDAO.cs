using Server.DTO;
using Server.env;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAO
{
    public class GroupChatDAO
    {
        private static GroupChatDAO instance;
        public static GroupChatDAO Instance
        {
            get { if (instance == null) instance = new GroupChatDAO(); return instance; }
            private set { instance = value; }
        }
        private GroupChatDAO() { }

        public void UpdateKeyGr(string us, string old_key, string new_key)
        {
            //Lấy danh sách các nhóm của bạn với tư cách trưởng nhóm
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhomChat WHERE username = N'" + us + "'");
            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    GroupChat myGr = new GroupChat(row);
                    myGr.GiaiMaPassGr(old_key);
                    myGr.MaHoaPassGr(new_key);
                    myGr.TenNhom = row["tennhom"].ToString();
                    string query_updatePassGr = "UPDATE NhomChat SET matkhau = N'" + myGr.MatKhau + "' WHERE tennhom = N'" + myGr.TenNhom + "'";
                    DataProvider.Instance.ExecuteNonQuery(query_updatePassGr);
                    DataTable da = DataProvider.Instance.ExecuteQuery("SELECT noidung FROM TinNhan_NhomChat WHERE tennhom = N'"
                        + myGr.TenNhom + "'");
                    if (da.Rows.Count > 0)
                    {
                        foreach (DataRow item in da.Rows)
                        {
                            myGr.TinNhan = item["noidung"].ToString();
                            myGr.GiaiMaTinNhan(old_key);
                            myGr.MaHoaTinNhan(new_key);
                            string query_updateMess = "UPDATE TinNhan_NhomChat SET noidung = N'" + myGr.TinNhan + "' WHERE tennhom = N'" + myGr.TenNhom + "'";
                            DataProvider.Instance.ExecuteNonQuery(query_updateMess);
                        }
                    }
                }
            }
        }//Update lại dữ liệu khi key thay đổi
        public bool KiemTraGr(string gn)
        {
            string query = "SELECT * FROM NhomChat WHERE tennhom = '" + gn + "'";
            DataTable check = DataProvider.Instance.ExecuteQuery(query);
            if (check != null && check.Rows.Count > 0)//Đã tồn tại
                return true;
            else
                return false;
        } //Kiểm tra nhóm đã tồn tại hay chưa
        public void CreateGr(string gn, string pass, string us)
        {
            string query = "INSERT INTO NhomChat VALUES(N'" + gn + "',N'"
                           + pass + "',N'"
                           + us + "')";
            DataProvider.Instance.ExecuteNonQuery(query);
        }//Tạo nhóm mới
        public string LoadGroup(string us)
        {
            GroupChat gc = new GroupChat();
            gc.Username = us;
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhomChat_ThanhVien WHERE username = N'" + 
                gc.Username + "' AND trangthai = N'Đang Trong Nhóm'");
            string traloi = "";
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    traloi += item["tennhom"].ToString() + "~" + item["username"].ToString();
                    string query_check_truongnhom = "SELECT * FROM NhomChat WHERE tennhom =N'" +
                    item["tennhom"].ToString() + "'";
                    DataTable dt = DataProvider.Instance.ExecuteQuery(query_check_truongnhom);
                    //Lấy username của trưởng nhóm và từ username đó lấy key chung của nhóm
                    foreach (DataRow i in dt.Rows)
                    {
                        string keygr = TakeKey(i["username"].ToString());
                        if (i["username"].ToString() == gc.Username)
                        {
                            MD5Helper md5 = new MD5Helper(keygr);
                            traloi += "~truongnhom~" + md5.GiaiMa(i["matkhau"].ToString()) + "^";
                        }
                        else
                            traloi += "~thanhvien~" + keygr + "^"; ;
                    }
                }
                //Ket qua tra loi =  tên nhóm ~ tên thành viên ~ chức vụ ~ mật khẩu nhóm ^ (nếu là trưởng nhóm)
                //KetQua tra lời = tên nhóm ~ tên thành viên ~ chức vụ ~ key chung của nhóm ^( nếu là thành viên)
                return traloi = traloi.Substring(0, traloi.Length - 1);
            }
            else
                return traloi = "[NULL]";
        } //Tải danh sách nhóm
        public bool LoginGr(string gn, string pass)
        {
            string query = "EXEC USP_JoinGroup N'" + gn + "',N'" + pass + "'";
            DataTable check = DataProvider.Instance.ExecuteQuery(query);
            if (check.Rows.Count == 0)
                return false; // Nhập nhóm sai
            else
                return true;
        }//Login vào Gr
        public bool StatusMember(string gn, string us)
        {
            string query = "SELECT * FROM NhomChat_ThanhVien WHERE username = N'" + us +
                "' AND tennhom = N'" + gn + "'";
            DataTable check = DataProvider.Instance.ExecuteQuery(query);
            if (check.Rows.Count != 0)
                return true;//Bị trong danh sách bị kích
            else
                return false;// Không danh sách bị kick
        }//Kiểm tra trạng thái của member trong 1 nhóm
        public void JoinGr(string us, string gn)
        {
            string query = "INSERT INTO NhomChat_ThanhVien(username, tennhom, trangthai) VALUES(N'" + us + "',N'"
                + gn + "',N'Đang Trong Nhóm')";//Insert vào thành viên nhóm
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DelGr(string gn)
        {
            string query = "DELETE NhomChat Where tennhom = N'" + gn + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void OutGr(string us, string gn)
        {
            //string query = "DELETE NhomChat_Thanhvien Where tennhom = N'" + gn + "' AND username = N'" + us + "'";
            string query = "DELETE NhomChat_Thanhvien Where tennhom = N'" 
                + gn + "' AND username = N'" + us + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InvaiteGr(string us, string gn)
        {
            string query = "UPDATE NhomChat_ThanhVien SET trangthai = N'Đang Trong Nhóm' WHERE tennhom = N'" + gn +
                "' AND username = N'" + us + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int GrLoading(string us)
        {
            string query = "SELECT tennhom FROM NhomChat_ThanhVien WHERE username = N'" +
                us + "' AND trangthai = N'Đang Trong Nhóm'";
            DataTable da_Gr = DataProvider.Instance.ExecuteQuery(query);
            if (da_Gr != null && da_Gr.Rows.Count > 0)
            {
                return da_Gr.Rows.Count;
            }
            else
                return 0;
        }
        public int MemLoading(string gn)
        {
            string query = "SELECT username FROM NhomChat_ThanhVien WHERE tennhom = N'" + 
                gn + "' AND trangthai = N'Đang Trong Nhóm'";
            DataTable da_Mem = DataProvider.Instance.ExecuteQuery(query);
            if (da_Mem != null && da_Mem.Rows.Count > 1)
            {
                return da_Mem.Rows.Count - 1 ;//Trừ 1 là trừ đi admin
            }
            else
                return 0;
        }
        public string SendToGr(string Username, string TenNhom, string TinNhan)
        {
           GroupChat gc = new GroupChat();
            string trangthai;
            gc.Username = Username;
            gc.TenNhom = TenNhom;
            gc.TinNhan = TinNhan;
            gc.MaHoaTinNhan(TakeKeyGroup(gc.TenNhom));
            string query = "SELECT * FROM NhomChat_ThanhVien WHERE tennhom = N'" + gc.TenNhom + "' AND trangthai = N'Đang Trong Nhóm'";
            DataTable dl = DataProvider.Instance.ExecuteQuery(query);
            if (dl != null && dl.Rows.Count > 0)
            {
                for (int i = 0; i < dl.Rows.Count; i++) //Vòng lặp gửi cho từng thành viên
                {
                    if (dl.Rows[i][0].ToString() == gc.Username)
                        trangthai = "Đã Nhận";
                    else
                        trangthai = "Đã Gửi";
                    string querysend2 = "Insert Into TinNhan_NhomChat(username, tennhom, noidung, trangthai, " +
                        "thoigian, nguoigui) Values(N'"
                    + dl.Rows[i][0].ToString() + "', N'"
                    + gc.TenNhom + "', N'"
                    + gc.TinNhan + "',N'" + trangthai + "', N'"
                    + DateTime.Now.ToString() + "',N'"
                    + gc.Username + "')";
                    DataProvider.Instance.ExecuteNonQuery(querysend2);
                }
            }
            string query3 = "SELECT MAX(id) FROM TinNhan_NhomChat WHERE tennhom  = N'" +
                   gc.TenNhom + "' AND nguoigui= N'" + gc.Username + "'";
            string last_id = DataProvider.Instance.ExecuteQuery(query3).Rows[0][0].ToString();
            return "[DONE]~" + gc.Username + "~" + last_id;
        }
        public string CheckMessGr(string us, string gn)
        {
            GroupChat gc = new GroupChat();
            gc.Username = us;
            gc.TenNhom = gn;
            MD5Helper md5 = new MD5Helper(TakeKeyGroup(gc.TenNhom));
            string query = "SELECT * FROM TinNhan_NhomChat WHERE tennhom = N'" + gc.TenNhom + "' " +
                "and trangthai = N'Đã Nhận' and username =N'" + gc.Username + "'";
            DataTable mess = DataProvider.Instance.ExecuteQuery(query);
            string traLoi = "";
            string tenhienthi;
            if (mess != null && mess.Rows.Count > 0)//Có tin nhắn
            {
                foreach (DataRow r in mess.Rows)
                {
                    if (gc.Username == r["nguoigui"].ToString())
                        tenhienthi = "Bạn";
                    else
                        tenhienthi = DisPlayName(r["nguoigui"].ToString());
                    traLoi += tenhienthi + "~" + MD5Helper.Instance.MaHoa(md5.GiaiMa(r["noidung"].ToString())) + "~"
                        + r["thoigian"].ToString() + "~" + r["nguoigui"].ToString() + "~"  +
                        gc.Username + "^";
                }
                return traLoi = traLoi.Substring(0, traLoi.Length - 1);
                //Trả lời : tên hiển thị + nội dung + time + username người gửi + username người yc+ trạng thái tin nhắn
            }
            else//Không có  tin nhắn
            {
                return traLoi = "NULL";
            }
        }
        public string NewMessGr(string us, string gn)
        {
            GroupChat gc = new GroupChat();
            gc.Username = us;
            gc.TenNhom = gn;
            MD5Helper md5 = new MD5Helper(TakeKeyGroup(gc.TenNhom));
            string query2 = "SELECT * FROM NhomChat_ThanhVien WHERE trangthai = N'Đang Trong Nhóm' AND tennhom = N'" +
                gn + "' AND username = N'" + gc.Username + "'";
            DataTable check = DataProvider.Instance.ExecuteQuery(query2);
            if (check.Rows.Count > 0)
            {
                string query = "SELECT * FROM TinNhan_NhomChat WHERE tennhom = N'" + gc.TenNhom + "' and " +
                "trangthai = N'Đã Gửi' and username = N'" + gc.Username + "'";
                DataTable mess = DataProvider.Instance.ExecuteQuery(query);
                string traLoi = "";
                if (mess != null && mess.Rows.Count > 0)//Có tin nhắn
                {
                    foreach (DataRow r in mess.Rows)
                    {
                        string nguoigui = DisPlayName(r["nguoigui"].ToString());
                        traLoi += nguoigui + "~" + MD5Helper.Instance.MaHoa(md5.GiaiMa(r["noidung"].ToString())) + "~"
                            + r["thoigian"].ToString() + "~" + r["nguoigui"].ToString() + "~" 
                            + gc.Username + "^";
                    }
                    foreach (DataRow r in mess.Rows)
                    {
                        String queryupdate = "Update TinNhan_NhomChat Set trangthai = N'Đã Nhận' Where tennhom = N'" + gc.TenNhom
                            + "' and username = N'" + gc.Username + "'";
                        DataProvider.Instance.ExecuteNonQuery(queryupdate);
                    }
                    return traLoi = traLoi.Substring(0, traLoi.Length - 1);
                    //trả lời =  tên hiển thị ~ nội dung ~ time ~ username người gửi ~ us người nhận
                }
                else//Không có  tin nhắn
                {
                    return traLoi = "NULL";
                }

            }// Không bị Kick
            else
            {
                return "NotInGr";
            }//Bị kick
        }
        public string LoadMemGr(string us, string gn)
        {
            GroupChat gc = new GroupChat();
            gc.Username = us;
            string traloi = "";
            string query = "SELECT username FROM NhomChat_ThanhVien WHERE username != N'" +
                gc.Username + "' and tennhom = N'" + gn + "' AND trangthai = N'Đang Trong Nhóm'";
            DataTable da_usMem = DataProvider.Instance.ExecuteQuery(query);
            if (da_usMem != null && da_usMem.Rows.Count > 0)//Có tin nhắn
            {
                foreach (DataRow r in da_usMem.Rows)
                {
                    traloi += r["username"].ToString() + "~" + DisPlayName(r["username"].ToString()) + "^";
                }
                return traloi.Substring(0, traloi.Length - 1);
            }
            else
                return traloi = "NULL";
        }
        public void KickMemGr(string gn, string us)
        {
            //Yc = [KGR] ~ groupname ~ us;
            string query = "UPDATE NhomChat_ThanhVien SET trangthai = N'Bị Kick' WHERE tennhom = N'" + 
                gn + "' AND username = N'" + us + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DelMess(string id,int count)
        {
            string temp = "";
            for(int i = int.Parse(id); i - count <= int.Parse(id); i++)
            {
                temp += i.ToString() + ",";
            }
            DataProvider.Instance.ExecuteNonQuery("UPDATE TinNhan_NhomChat SET noidung  = N'Đã bị thu hồi', " +
                "trangthai = N'Thu Hồi' WHERE id in ("+temp.Substring(0,temp.Length-1)+")");
        }
        private string DisPlayName(string us)
        {
            string query = "SELECT Displayname FROM ACCOUNT WHERE username = N'" + us + "'";
            DataTable ds = DataProvider.Instance.ExecuteQuery(query);
            if (ds != null && ds.Rows.Count > 0)
                return ds.Rows[0][0].ToString();
            else
                return "Không xác định";
        }//Lấy tên hiển thị
        public string TakeKey(string us)
        {
            string query = "SELECT sKey FROM ACCOUNT WHERE username = N'" + us + "'";
            DataTable ds = DataProvider.Instance.ExecuteQuery(query);
            if (ds != null && ds.Rows.Count > 0)
                return ds.Rows[0][0].ToString();
            else
                return "NULL";
        }
        public string TakeKeyGroup(string gn)
        {
            string query_check_truongnhom = "SELECT username FROM NhomChat WHERE tennhom =N'" +
                        gn + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query_check_truongnhom);
            if (dt != null && dt.Rows.Count > 0)
            {
                string traLoi = TakeKey(dt.Rows[0][0].ToString());
                return traLoi;
            }
            else
                return "NULL";
        }
    }
}
