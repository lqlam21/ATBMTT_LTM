using System.Data;

namespace Sever.DTO
{
    public class Data_File
    {
        public int Id { get; set; }
        public string NguoiGui { get; set; }
        public string KhoaCongKhai { get; set; }
        public byte[] DuLieu { get; set; }
        public string Tenfile { get; set; }

        public Data_File(DataRow row)
        {
            this.Id = (int)row["id"];
            this.NguoiGui = row["nguoigui"].ToString();
            this.KhoaCongKhai = row["khoacongkhai"].ToString();
            this.DuLieu = (byte[])row["dulieu"];
            this.Tenfile = row["tenfile"].ToString();
        }
        public Data_File(string nguoigui,string khoacongkhai, byte[] dulieu, string tenfile)
        {
            this.NguoiGui = nguoigui;
            this.KhoaCongKhai = khoacongkhai;
            this.DuLieu = dulieu;
            this.Tenfile = tenfile;

        }
        public Data_File()
        {

        }
    }
}
