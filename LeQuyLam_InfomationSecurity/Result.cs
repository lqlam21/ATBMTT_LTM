using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LeQuyLam_InfomationSecurity
{
    public class Result
    {
        private static Result instance;
        public static Result Instance
        {
            get { if (instance == null) instance = new Result(); return instance; }
            private set { instance = value; }
        }
        private Result() { }
        public String Request(String yeuCau)
        {
            // Gui du lieu
            String serverIP = "127.0.0.1";
            int port = 12000;

            System.Net.Sockets.Socket sk = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Ket noi den may chu
                sk.Connect(IPAddress.Parse(serverIP), port);

                // Chuyen yeu cau sang dang mang byte
                byte[] duLieu = Encoding.UTF8.GetBytes(yeuCau);

                // Gui yeu cau
                int dem = sk.Send(duLieu);

                // Nhan tra loi va hien thi
                byte[] ketQua = new byte[102400];
                int demNhan = sk.Receive(ketQua);
                String traLoi = Encoding.UTF8.GetString(ketQua, 0, demNhan);

                // Dong ket noi
                sk.Close();
                sk.Dispose();

                return traLoi;
            }
            catch
            {
                return null;
            }
        }
    }
}
