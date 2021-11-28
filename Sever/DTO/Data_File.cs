using System;
using System.Data;

namespace Sever.DTO
{
    public class Data_File
    {
        public int Id { get; set; }
        public string NguoiGui { get; set; }
        public byte[] DuLieu { get; set; }
        public string Tenfile { get; set; }
        public DateTime Time { get; set; }

        public Data_File(DataRow row)
        {
            this.Id = (int)row["id"];
            this.NguoiGui = row["nguoigui"].ToString();
            this.DuLieu = (byte[])row["dulieu"];
            this.Tenfile = row["tenfile"].ToString();
            this.Time = Convert.ToDateTime(row["ngaygui"]);
        }
        //public Data_File(string nguoigui, byte[] dulieu, string tenfile)
        //{
        //    this.NguoiGui = nguoigui;
        //    this.DuLieu = dulieu;
        //    this.Tenfile = tenfile;
        //}
        //public Data_File()
        //{

        //}
    }
}
