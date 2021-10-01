using System.Data;
using System.Data.SqlClient;


namespace Server.DAO
{


    public class DataProvider
    {
        //Tạo Singleton pattern
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }
        public DataProvider() { }
        private string connectionSTR = env.Security.sConnection;
        //Truy vấn câu lệnh sql
        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Load(dr, LoadOption.OverwriteChanges);
                    connection.Close();
                    return data;
                }
                catch
                {
                    return null;
                }

            }
        }
        //Thực thi câu lệnh sql
        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    int dem = command.ExecuteNonQuery();
                    connection.Close();
                    return dem;
                }
                catch
                {
                    return -1;
                }
            }
        }
    }
}
