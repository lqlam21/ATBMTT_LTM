using Server.DAO;
using Server.DTO;
using Server.env;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("May chu bat dau hoat dong ...");
            String serverIP = "127.0.0.1";
            int port = 12000;

            //Khởi tạo
            Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), port);
            sk.Bind(ep);
            sk.Listen(100);

            while (true)
            {
                //Chấp nhận kết nối
                Socket skXL = sk.Accept();
                //Nhận dữ liệu
                Byte[] duLieu = new byte[102400000];
                int demNhan = skXL.Receive(duLieu);
                String noiDung = Encoding.UTF8.GetString(duLieu, 0, demNhan);
                if (noiDung.StartsWith("[DangNhap]"))
                {
                    //Đăng nhập: [DangNhap] ~ usernam ~ password
                    User us = new User();
                    String username = noiDung.Split('~')[1];
                    String password = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[2]);
                    us.Username = username;
                    us.Password = password;
                    //Truy vấn
                    String traLoi = "";
                    if (AccountDAO.Instance.Login(us.Username, us.Password))
                    {
                        User thongTinUser = InfoDAO.Instance.LoadInfo(us.Username);
                        thongTinUser.GiaiMaEmail(thongTinUser.Key);
                        traLoi = MD5Helper.Instance.MaHoa(thongTinUser.Namedisplay) + "~" + thongTinUser.Email + "~" + thongTinUser.Type 
                            + "~" + thongTinUser.Key;
                        traLoi = traLoi.Substring(0, traLoi.Length);
                        Console.WriteLine( username + "- ket noi");
                    }
                    else
                    {
                        //Sai tai khoan
                        traLoi = "[NULL]";
                    }
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Đăng nhập
                else if (noiDung.StartsWith("[DangKy]"))
                {
                    //Đăng ký: [DangKy] ~ DisPlayName ~ Key ~ Pass ~ Email ~ Username
                    string displayname = noiDung.Split('~')[1];
                    string key = noiDung.Split('~')[2];
                    string password = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[3]);
                    string email = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[4]);
                    string username = noiDung.Split('~')[5];
                    User thongTinUser = new User(displayname, email, username, password, 1, key);
                    thongTinUser.MaHoaEmail(thongTinUser.Key);
                    Console.WriteLine(username + "- Dang ky thanh cong");
                    AccountDAO.Instance.DangKy(thongTinUser.Namedisplay, thongTinUser.Email, thongTinUser.Username,
                        thongTinUser.Password, thongTinUser.Key);
                    byte[] traLoi = Encoding.UTF8.GetBytes("OK");
                    skXL.Send(traLoi);

                }//Đăng ký
                else if (noiDung.StartsWith("[SendMail]"))
                {//YC = [SendMail] ~ Email
                    string email = noiDung.Split('~')[1];
                    Random rd = new Random();
                    int code = rd.Next(0, 9999);
                    fnSendMail(email, code.ToString("D4"));
                    byte[] traLoi = Encoding.UTF8.GetBytes(code.ToString("D4"));
                    skXL.Send(traLoi);
                }//Gửi mã xác thực
                else if (noiDung.StartsWith("[DoiPass]"))//Đổi pass
                {
                    //Đổi pass: [DoiPass]~ username ~ password ~ pass_new
                    User us = new User();
                    us.Username = noiDung.Split('~')[1];
                    us.Password = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[2]);
                    us.Passnew = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[3]);

                    byte[] traLoi;
                    if (AccountDAO.Instance.Login(us.Username, us.Password))
                    {
                        AccountDAO.Instance.DoiPass(us.Username, us.Passnew);
                        traLoi = Encoding.UTF8.GetBytes("DONE");
                        Console.WriteLine(us.Username + "- Doi pass thanh cong");
                    }
                    else
                    {
                        traLoi = Encoding.UTF8.GetBytes("WRONG");
                    }
                    skXL.Send(traLoi);
                }//Đổi pass
                else if (noiDung.StartsWith("[UpdateSecondSecurity]"))
                {
                    //Update Bảo vệ 2 lớp: [UpdateSecondSecurity]~ username ~ password ~ type
                    User us = new User();
                    us.Username = noiDung.Split('~')[1];
                    us.Password = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[2]);
                    string type = noiDung.Split('~')[3];
                    byte[] traLoi = Encoding.UTF8.GetBytes("OK");

                    if (AccountDAO.Instance.Login(us.Username, us.Password) && type == "1")
                    {
                        AccountDAO.Instance.OnSecondSecurity(us.Username);
                        traLoi = Encoding.UTF8.GetBytes("T1");//Đang tắt
                        Console.WriteLine(us.Username + "- Bat bao ve thanh cong");
                    }
                    else if (AccountDAO.Instance.Login(us.Username, us.Password) && type == "2")
                    {
                        AccountDAO.Instance.OffSecondSecurity(us.Username);
                        traLoi = Encoding.UTF8.GetBytes("T2");//Đang bật
                        Console.WriteLine(us.Username + "- Tat bao ve thanh cong");
                    }
                    else
                    {
                        traLoi = Encoding.UTF8.GetBytes("WRONG");//Sai mật khẩu
                    }
                    skXL.Send(traLoi);
                }//Bật tắt bảo vệ
                else if (noiDung.StartsWith("[DoiTen]"))
                {
                    //Đổi key: [DoiTen] ~ username ~ newname
                    User us = new User();
                    us.Username = noiDung.Split('~')[1];
                    string newname = noiDung.Split('~')[2];
                    AccountDAO.Instance.Rename(us.Username, newname);
                    byte[] traLoi = Encoding.UTF8.GetBytes("OK");
                    Console.WriteLine(us.Username + "- Doi ten thanh cong");
                    skXL.Send(traLoi);
                }//Đổi tên
                else if (noiDung.StartsWith("[DoiKey]"))//Đổi key
                {
                    //Đổi key: [DoiKey] ~ username ~ newkey
                    User us = new User();
                    us.Username = noiDung.Split('~')[1];
                    string NewKey = noiDung.Split('~')[2];
                    //Đồng bộ lại dữ liệu
                    User thongTinUser = InfoDAO.Instance.LoadInfo(us.Username);
                    //Email
                    thongTinUser.GiaiMaEmail(thongTinUser.Key);
                    thongTinUser.MaHoaEmail(NewKey);
                    AccountDAO.Instance.UpdateMail(us.Username, thongTinUser.Email);
                    //Group
                    GroupChatDAO.Instance.UpdateKeyGr(us.Username, thongTinUser.Key, NewKey);
                    //GroupChat MyGr = 
                    AccountDAO.Instance.EditKey(us.Username, NewKey);

                    byte[] traLoi = Encoding.UTF8.GetBytes("OK");
                    Console.WriteLine(us.Username + "- Doi key thanh cong");
                    skXL.Send(traLoi);
                }//Đổi mã khóa
                else if (noiDung.StartsWith("[KiemTraTaiKhoan]"))
                {
                    //Kiểm tra tài khoản: [KiemTraTaiKhoan] ~ username
                    User us = new User();
                    us.Username = noiDung.Split('~')[1];
                    bool check = AccountDAO.Instance.KiemTraTK(us.Username); 
                    string traLoi;
                    if (check) //Đã tồn tại
                        traLoi = "DTT";
                    else //Hợp lệ
                        traLoi = "HL";
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Kiểm tra tên tài khoản 
                else if (noiDung.StartsWith("[LayDuLieu]"))
                {
                    //info: [LayDuLieu] ~ username
                    User us = new User();
                    us.Username = noiDung.Split('~')[1];
                    String traLoi = "";
                    User thongTinUser = InfoDAO.Instance.LoadInfo(us.Username);
                    thongTinUser.GiaiMaEmail(thongTinUser.Key);
                    traLoi = thongTinUser.Namedisplay + "~" + thongTinUser.Email + "~" + thongTinUser.Type
                        + "~" + thongTinUser.Key;
                    traLoi = traLoi.Substring(0, traLoi.Length);
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Lấy dữ liệu tài khoản
                else if (noiDung.StartsWith("[GopY]"))
                {
                    //info: [GopY] ~ danhgia ~ ykien
                    string danhgia = noiDung.Split('~')[1];
                    string ykien = noiDung.Split('~')[2];
                    DataProvider.Instance.ExecuteNonQuery("INSERT INTO GopY VALUES(N'" + ykien + "', N'" + danhgia + "')");
                    skXL.Send(Encoding.UTF8.GetBytes("DONE"));
                    Console.WriteLine("Nhan 1 gop y");
                }//Góp ý hệ thống
                else if (noiDung.StartsWith("[TaoNhom]"))
                {
                    //Yc = [TaoNhom] ~ username ~ tên nhóm ~ mật khậu nhóm
                    GroupChat gc = new GroupChat();
                    gc.Username = noiDung.Split('~')[1];
                    gc.TenNhom = noiDung.Split('~')[2];
                    gc.MatKhau = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[3]);
                    gc.MaHoaPassGr(GroupChatDAO.Instance.TakeKey(gc.Username));
                    //Kiểm tra tên nhóm đã tồn tại hay chưa
                    bool check = GroupChatDAO.Instance.KiemTraGr(gc.TenNhom);
                    string traLoi;
                    if (check)
                    {
                        //nhóm đã tồn tại
                        traLoi = "DTT";
                    }
                    else
                    {
                        GroupChatDAO.Instance.CreateGr(gc.TenNhom, gc.MatKhau, gc.Username);
                        GroupChatDAO.Instance.JoinGr(gc.Username, gc.TenNhom);
                        Console.WriteLine(gc.Username + "- Tao nhom moi -" + gc.TenNhom);
                        traLoi = "TC";
                    }
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));

                }//Tạo nhóm chat
                else if (noiDung.StartsWith("[LoadGroup]"))
                {
                    //Yc = [CG] ~ username
                    string username = noiDung.Split('~')[1];
                    string traloi = GroupChatDAO.Instance.LoadGroup(username);
                    skXL.Send(Encoding.UTF8.GetBytes(traloi));
                }//Xem danh sách nhóm đã tham gia
                else if (noiDung.StartsWith("[TimNhom]"))
                {
                    //Yc = [TimNhom] ~ username ~ tên nhóm ~ mật khậu nhóm
                    GroupChat gc = new GroupChat();
                    gc.Username = noiDung.Split('~')[1];
                    gc.TenNhom = noiDung.Split('~')[2];
                    gc.MatKhau = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[3]);
                    gc.MaHoaPassGr(GroupChatDAO.Instance.TakeKeyGroup(gc.TenNhom));
                    //Kiểm tra tên nhóm có tồn tại hay không
                    bool check = GroupChatDAO.Instance.LoginGr(gc.TenNhom, gc.MatKhau);
                    bool check2 = GroupChatDAO.Instance.StatusMember(gc.TenNhom, gc.Username);
                    string traLoi;
                    if (!check)
                    {
                        //nhóm không tồn tại hoặc sai mật khẩu
                        traLoi = "KTT";
                    }
                    else if(check2  && check)
                    {
                        traLoi = "BLOCK";
                    }
                    else
                    {
                        GroupChatDAO.Instance.JoinGr(gc.Username, gc.TenNhom);
                        Console.WriteLine(gc.Username + "- Tham gia nhom.");
                        traLoi = "TC";
                    }
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Tìm và vào nhóm
                else if (noiDung.StartsWith("[DelGr]"))
                {                    //Yêu cầu xóa: [DelGr] ~ tên nhóm
                    GroupChat gc = new GroupChat();
                    gc.TenNhom = noiDung.Split('~')[1];
                    GroupChatDAO.Instance.DelGr(gc.TenNhom);
                    skXL.Send(Encoding.UTF8.GetBytes("TC"));
                    Console.WriteLine("Xoa nhom -" + gc.TenNhom);
                }//Xóa nhóm
                else if (noiDung.StartsWith("[OutGr]"))
                {                    //Yêu cầu rời: [OutGr] ~ tên nhóm ~ username
                    GroupChat gc = new GroupChat();
                    gc.TenNhom = noiDung.Split('~')[1];
                    gc.Username = noiDung.Split('~')[2];
                    GroupChatDAO.Instance.OutGr(gc.Username, gc.TenNhom);
                    skXL.Send(Encoding.UTF8.GetBytes("TC"));
                    Console.WriteLine(gc.Username + "- Roi nhom -" + gc.TenNhom);
                }//Rời nhóm
                else if (noiDung.StartsWith("[SendMTGroup]")){
                    //Yc Gửi tin nhắn = [SendMTGroup] ~ username ~ groupname ~ noidung
                    string username = noiDung.Split('~')[1];
                    string tennhom = noiDung.Split('~')[2];
                    string noidung = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[3]);
                    string traLoi = GroupChatDAO.Instance.SendToGr(username, tennhom, noidung);
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Gửi tin nhắn vào nhóm
                else if (noiDung.StartsWith("[CheckMIGroup]"))
                {
                    //Yc load tin nhắn = [CheckMIGroup] ~ username ~ groupname ~ stt
                    string username = noiDung.Split('~')[1];
                    string groupname = noiDung.Split('~')[2];
                    string stt = noiDung.Split('~')[3];
                    string traLoi = GroupChatDAO.Instance.CheckMessGr(username, groupname,stt);
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Tải tin nhắn 
                else if (noiDung.StartsWith("[NewMessGroup]"))
                {
                    //Yc load tin nhắn = [NewMessGroup] ~ username ~ groupname
                    GroupChat gc = new GroupChat();
                    string username = noiDung.Split('~')[1];
                    string tennhom = noiDung.Split('~')[2];
                    string traLoi = GroupChatDAO.Instance.NewMessGr(username, tennhom);
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Tải tin nhắn mới
                else if (noiDung.StartsWith("[NewMessGroup_Del]"))
                {
                    //Yc load tin nhắn = [NewMessGroup_Del] ~ username ~ groupname
                    GroupChat gc = new GroupChat();
                    string username = noiDung.Split('~')[1];
                    string tennhom = noiDung.Split('~')[2];
                    string traLoi = GroupChatDAO.Instance.NewMessGr_Del(username, tennhom);
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Tải tin nhắn mới
                else if (noiDung.StartsWith("[LoadMemGr]"))
                {
                    //Yc load thành viên nhóm = [LoadMemGr] ~ username ~ groupname
                    //noiDung.Split('~')[1] = username
                    //noiDung.Split('~')[2] = groupname
                    string traLoi = GroupChatDAO.Instance.LoadMemGr(noiDung.Split('~')[1], noiDung.Split('~')[2]);
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Load thành viên trong nhóm chat
                else if (noiDung.StartsWith("[KGR]"))
                {
                    //Yc = [KGR] ~ groupname ~ us;
                    //noiDung.Split('~')[1] = groupname
                    //noiDung.Split('~')[2] = us bi kich
                    GroupChatDAO.Instance.KickMemGr(noiDung.Split('~')[1], noiDung.Split('~')[2]);
                    Console.WriteLine("-Kick khoi gr");
                    string traLoi = "DONE";
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Kick khỏi gr
                else if (noiDung.StartsWith("[MoiVaoNhom]"))
                {
                    //Yc = [MoiVaoNhom] ~ username ~ tên nhóm
                    GroupChat gc = new GroupChat();
                    gc.Username = noiDung.Split('~')[1];
                    gc.TenNhom = noiDung.Split('~')[2];
                    bool check = GroupChatDAO.Instance.StatusMember(gc.TenNhom, gc.Username); //Check trạng thái thành viên
                    //Check username có tồn tại trong CSDL hay không
                    bool check2 = AccountDAO.Instance.KiemTraTK(gc.Username);
                    if (check2)
                    {
                        if (!check) // Chưa từng tham gia nhóm và không ở trong nhóm
                        {
                            GroupChatDAO.Instance.JoinGr(gc.Username, gc.TenNhom);
                        }
                        else
                        {
                            GroupChatDAO.Instance.InvaiteGr(gc.Username, gc.TenNhom);
                        }
                        Console.WriteLine(gc.Username + "- Moi vao nhom.");
                        skXL.Send(Encoding.UTF8.GetBytes("TC"));
                    }
                    else
                    {
                        skXL.Send(Encoding.UTF8.GetBytes("TB"));
                    }
                }//Tìm và vào nhóm
                else if (noiDung.StartsWith("[?Gr]"))
                {
                    //Yc = [?Gr] ~ username
                    GroupChat gc = new GroupChat();
                    gc.Username = noiDung.Split('~')[1];
                    int slGr = GroupChatDAO.Instance.GrLoading(gc.Username);
                    string traLoi;
                    if (slGr > 0)
                    {
                        traLoi = slGr.ToString();
                    }
                    else
                    {
                        traLoi = "0";
                    }
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Update nhóm liên tục
                else if (noiDung.StartsWith("[?Member]"))
                {
                    //Yc = [?Member] ~ Group name
                    int slMem = GroupChatDAO.Instance.MemLoading(noiDung.Split('~')[1]);
                    string traLoi;
                    if( slMem >0)
                    {
                        traLoi = slMem.ToString();
                    }
                    else
                    {
                        traLoi = "0";
                    }
                    skXL.Send(Encoding.UTF8.GetBytes(traLoi));
                }//Update nhóm liên tục
                else if (noiDung.StartsWith("[DellMess]"))
                {
                    //YC: [DellMess] ~ id_mess
                    GroupChatDAO.Instance.DelMess(noiDung.Split('~')[1]);
                    skXL.Send(Encoding.UTF8.GetBytes("DONE"));
                }//Xóa tin nhắn
                else if (noiDung.StartsWith("[EditPassGr]")){
                    //Yc = [EditPassGr] ~ Username ~ Ten Nhom ~ Mật khẩu mới
                    GroupChat gc = new GroupChat
                    {
                        Username = noiDung.Split('~')[1],
                        TenNhom = noiDung.Split('~')[2],
                        MatKhau = MD5Helper.Instance.GiaiMa(noiDung.Split('~')[3])
                    };
                    gc.MaHoaPassGr(GroupChatDAO.Instance.TakeKey(gc.Username));
                    GroupChatDAO.Instance.EditPassGr(gc.TenNhom,gc.MatKhau);
                    skXL.Send(Encoding.UTF8.GetBytes("DONE"));
                }//Đổi mật khẩu nhóm
                else if (noiDung.StartsWith("[LoadFile]"))
                {
                    // [LoadFile]~usname
                    User us = new User {
                        Username = noiDung.Split('~')[1]
                    };
                    string response = fileDAO.Instance.LoadFileList(us.Username);
                    skXL.Send(Encoding.UTF8.GetBytes(response));
                }
                else if (noiDung.StartsWith("[DelFile]"))
                {
                    //[DelFile]~id File
                    fileDAO.Instance.DelFile(noiDung.Split('~')[1]);
                    skXL.Send(Encoding.UTF8.GetBytes("Done"));

                }
                else if (noiDung.StartsWith("[DownFile]"))
                {
                    //[DownFile]~id File
                    //fileDAO.Instance.DownFile(noiDung.Split('~')[1]);
                    skXL.Send(fileDAO.Instance.DownFile(noiDung.Split('~')[1]));
                }
                else if(duLieu[0] <= 20)
                {
                    // Nhan du lieu
                    List<byte> dt = new List<byte>();
                    for (int i = 0; i < demNhan; i++)
                        dt.Add(duLieu[i]);

                    // Xu ly du lieu nhan duoc
                    int chieuDaiUserName = dt[0];
                    byte[] bUsername = new byte[chieuDaiUserName];
                    for (int i = 1; i <= chieuDaiUserName; i++)
                    {
                        bUsername[i - 1] = dt[i];
                    }
                    int chieuDaiMaKhoa = dt[chieuDaiUserName + 1];
                    byte[] bMakhoa = new byte[chieuDaiMaKhoa];
                    for (int i = 1; i <= chieuDaiMaKhoa; i++)
                    {
                        bMakhoa[i - 1] = dt[chieuDaiUserName + 1 + i];
                    }
                    int chieuDaiHeader = dt[chieuDaiMaKhoa + chieuDaiUserName + 2];

                    byte[] bHeader = new byte[chieuDaiHeader];

                    for (int i = 1; i <= chieuDaiHeader; i++)
                        bHeader[i - 1] = dt[i + chieuDaiMaKhoa + chieuDaiUserName +2];
                    String tenTep = Encoding.UTF8.GetString(bHeader);
                    byte[] bnoiDungTep = new byte[dt.Count - chieuDaiHeader - 1 - chieuDaiMaKhoa - 1 - chieuDaiUserName -1];
                    for (int i = chieuDaiHeader + chieuDaiMaKhoa + chieuDaiUserName + 3; i < dt.Count; i++)
                        bnoiDungTep[i - (chieuDaiHeader + chieuDaiMaKhoa + chieuDaiUserName + 3)] = dt[i];
                    // Ghi noi dung tep 
                    var Makhoa = Encoding.UTF8.GetString(bMakhoa);
                    User us = new User
                    {
                        Username = Encoding.UTF8.GetString(bUsername)
                    };
                    //var Username = Encoding.UTF8.GetString(bUsername);
                    MD5Helper md5 = new MD5Helper(Makhoa);
                    byte[] bNoidungMahoa = md5.MaHoa(bnoiDungTep);
                    var id = fileDAO.Instance.WriteFile(us.Username, bNoidungMahoa, tenTep);
                    //String root = "D:\\";
                    //String duongDan = root + "\\" + tenTep;
                    //File.WriteAllBytes(duongDan, bNoidungMahoa);


                    // Hien thi len console
                    Console.WriteLine("Da nhan tep: " + tenTep);

                    // Tra loi cho client
                    byte[] traLoi = Encoding.UTF8.GetBytes("DONE~"+ id);
                    skXL.Send(traLoi);
                }//Up file
                // Đóng kết nối
                skXL.Close();
                skXL.Dispose();
            }
            #region Sendmail
            void fnSendMail(string sMail, string sCod)
            {
                SendMail sm = new SendMail(sMail, sCod);
                sm.SendEmail();
            }//Gửi code đến sMail
            #endregion
            //Lấy Key
        }
    }
}
