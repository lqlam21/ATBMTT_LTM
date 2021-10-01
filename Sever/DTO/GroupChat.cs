using Server.env;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class GroupChat
    {
        public GroupChat(DataRow row)
        {
            this.TenNhom = row["tennhom"].ToString();
            this.MatKhau = row["matkhau"].ToString();
            this.Username = row["username"].ToString();
        }

        public GroupChat(string tennhom, string matkhau, string username)
        {
            this.TenNhom = tennhom;
            this.Username = username;
            this.MatKhau = matkhau;
        }
        
        public GroupChat(){}

        private string username;
        private string tennhom;
        private string matkhau;
        private string tinnhan;

        public string Username { get => username; set => username = MD5Helper.Instance.MaHoaMotChieu(value); }
        public string TenNhom { get => MD5Helper.Instance.GiaiMa(tennhom); set => tennhom =MD5Helper.Instance.MaHoa(value); }
        public string MatKhau { get => matkhau; set => matkhau = value; }
        public string TinNhan { get => tinnhan; set => tinnhan = value; }

        public void MaHoaPassGr(string key)
        {
            MD5Helper md = new MD5Helper(key);
            this.MatKhau = md.MaHoa(this.MatKhau);
        }
        public void GiaiMaPassGr(string key)
        {
            MD5Helper md = new MD5Helper(key);
            this.MatKhau = md.GiaiMa(this.MatKhau);
        }

        public void MaHoaTinNhan(string key)
        {
            MD5Helper md = new MD5Helper(key);
            this.TinNhan = md.MaHoa(this.TinNhan);
        }

        public void GiaiMaTinNhan(string key)
        {
            MD5Helper md = new MD5Helper(key);
            this.TinNhan = md.GiaiMa(this.TinNhan);
        }
        
    }
}
