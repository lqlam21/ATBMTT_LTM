using Server.env;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class NC_TV
    {
        public NC_TV(DataRow row)
        {
            this.TenNhom = row["tennhom"].ToString();
            this.Username = row["username"].ToString();
        }
        public NC_TV(string tennhom, string matkhau, string username)
        {
            this.TenNhom = tennhom;
            this.Username = username;
        }
        public NC_TV() { }

        private string username;
        private string tennhom;

        public string Username { get => username; set => username = MD5Helper.Instance.MaHoaMotChieu(value); }
        public string TenNhom { get => MD5Helper.Instance.GiaiMa(tennhom); set => tennhom = MD5Helper.Instance.MaHoa(value); }


    }
}
