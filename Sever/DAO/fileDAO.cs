using Sever.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAO
{
    public class fileDAO
    {
        private static fileDAO instance;
        public static fileDAO Instance
        {
            get { if (instance == null) instance = new fileDAO(); return instance; }
            private set { instance = value; }
        }
        private fileDAO() { }

        public string WriteFile(string tennguoigui, byte[] noidungfile , string tenfile)
        {
            string connectionSTR = env.Security.sConnection;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();
                    //string query = "INSERT INTO Data_File VALUES N'{tennguoigui}'" +
                    //$", N'{noidungfile}' , N'{tenfile}', N'{DateTime.Now}' ";
                    string query = "INSERT INTO Data_File(nguoigui,dulieu,tenfile,ngaygui) " +
                        "VALUES (@nguoigui, @dulieu, @tenfile, @ngaygui)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlParameter parameter1 = cmd.Parameters.AddWithValue("@nguoigui", tennguoigui);
                    parameter1.DbType = DbType.String;
                    SqlParameter parameter2 = cmd.Parameters.AddWithValue("@dulieu", noidungfile);
                    parameter2.DbType = DbType.Binary;
                    SqlParameter parameter3 = cmd.Parameters.AddWithValue("@tenfile", tenfile);
                    parameter3.DbType = DbType.String;
                    SqlParameter parameter4 = cmd.Parameters.AddWithValue("@ngaygui", DateTime.Now);
                    parameter4.DbType = DbType.DateTime;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    //try
                    //{
                    //    connection.Open();
                    //    int dem = cmd.ExecuteNonQuery();
                    //    connection.Close();
                    //}
                    //catch
                    //{

                    //}
                }

            string qr2 = "SELECT MAX(id) FROM Data_File WHERE nguoigui = N'" +
                tennguoigui + "'";
            var da = DataProvider.Instance.ExecuteQuery(qr2);
            return da.Rows[0][0].ToString();
        }
        public string LoadFileList(string usname)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"SELECT * FROM Data_File WHERE nguoigui = N'{usname}'");
            if (data.Rows.Count > 0)
            {
                string response = "";
                // chuyển DataTable thành AccountList
                foreach (DataRow item in data.Rows)
                {
                    Data_File info = new Data_File(item);
                    string[] arrListfname = info.Tenfile.Split('.');
                    response += info.Id + "~" + arrListfname[0]+".***" + "^";

                }
                return response.Substring(0, response.Length - 1);
            }
            else
                return "null";
        }
        public void DelFile(string id)
        {
            string query = "DELETE Data_File WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public byte[] DownFile(string id)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT dulieu,tenfile FROM Data_File WHERE id = " 
                + id);
            string tenTep = dt.Rows[0][1].ToString();
            tenTep = tenTep.Replace(" ", "_");
            byte[] bHeader = Encoding.UTF8.GetBytes(tenTep);
            byte[] bnoiDungTep = (byte[])dt.Rows[0][0];
            byte[] bResponse = new byte[bHeader.Length + 1 + bnoiDungTep.Length];
            bResponse[0] = (byte)bHeader.Length;
            for (int i = 0; i < bHeader.Length; i++)
            {
                bResponse[i + 1] = bHeader[i];
            }
            // Ghep noi dung tep vao mang byte gui di
            for (int i = 0; i < bnoiDungTep.Length; i++)
            {
                bResponse[i + 1 + bHeader.Length] = bnoiDungTep[i];
            }

            return bResponse;
        }
    }
}
