using System;
using System.Security.Cryptography;
using System.Text;

namespace Server.env
{
    public class MD5Helper
    {
        public String MatKhau { get; set; }
        //Tạo Singleton pattern
        private static MD5Helper instance;
        public static MD5Helper Instance
        {
            get { if (instance == null) instance = new MD5Helper(); return instance; }
            private set { instance = value; }
        }
        private MD5Helper() { MatKhau = "1h87h8712j".Trim(); }// Để tạm mật khẩu mã hóa mặc định là 1h87h8712j
        //Constructors
        public MD5Helper(String matKhau)
        {
            MatKhau = matKhau;
        }
        //Method
        public string MaHoaMotChieu(string duLieuCanMaHoa)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(duLieuCanMaHoa);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public String MaHoa(String duLieuCanMaHoa)
        {
            byte[] input = Encoding.UTF8.GetBytes(duLieuCanMaHoa);
            byte[] output = MaHoa(input);
            return Convert.ToBase64String(output, 0, output.Length);
        }

        public String GiaiMa(String duLieuCanGiaiMa)
        {
            byte[] input = Convert.FromBase64String(duLieuCanGiaiMa);
            byte[] output = GiaiMa(input);
            return Encoding.UTF8.GetString(output);
        }


        public byte[] MaHoa(byte[] duLieuCanMaHoa)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
                {
                    des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(MatKhau));
                    des.Mode = CipherMode.ECB;
                    des.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform tran = des.CreateEncryptor())
                    {
                        byte[] output = tran.TransformFinalBlock(duLieuCanMaHoa, 0, duLieuCanMaHoa.Length);
                        return output;
                    }
                }
            }
        }


        public byte[] GiaiMa(byte[] duLieuCanGiaiMa)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
                {
                    des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(MatKhau));
                    des.Mode = CipherMode.ECB;
                    des.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform tran = des.CreateDecryptor())
                    {
                        try
                        {
                            byte[] output = tran.TransformFinalBlock(duLieuCanGiaiMa, 0, duLieuCanGiaiMa.Length);
                            return output;
                        }
                        catch
                        {
                            return Encoding.UTF8.GetBytes("[Key bị thay đổi]-Để xem lại cần set về key cũ");
                        }
                    }
                }
            }
        }
    }
}
