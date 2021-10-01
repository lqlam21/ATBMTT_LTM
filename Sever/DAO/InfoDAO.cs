using Server.DTO;
using System.Collections.Generic;
using System.Data;


namespace Server.DAO
{
    public class InfoDAO
    {
        private static InfoDAO instance;

        public static InfoDAO Instance
        {
            get { if (instance == null) instance = new InfoDAO(); return instance; }
            private set { instance = value; }
        }
        private InfoDAO() { }
        public List<User> LoadAccountList()
        {
            List<User> AccountList = new List<User>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ACCOUNT");
            // chuyển DataTable thành AccountList
            foreach (DataRow item in data.Rows)
            {
                User info = new User(item);
                AccountList.Add(info);
            }
            return AccountList;
        }

        public User LoadInfo(string username)
        {
            DataTable da = DAO.DataProvider.Instance.ExecuteQuery("EXEC USP_InfoAccount N'" + username + "'");
            User info = new User(da.Rows[0]);
            return info;
        }
    }
}
