using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string userName, string password)
        {
            string query = "EXEC USP_Login '"+ userName+"','" + password+"'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public void DangKy(string namedisplay, string email, string username, string password, string key)
        {
            string query = "INSERT INTO ACCOUNT(Displayname, Email, Username, Password,type,sKey)  VALUES ( N'"
                                                            + namedisplay + "',N'"
                                                            + email + "',N'"
                                                            + username + "',N'"
                                                            + password + "',1,N'" + key + "')";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DoiPass(string us,string passnew)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_PassWord N'" + us + "',N'" + passnew + "'");
        }
        public void OnSecondSecurity(string us)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_UpdateType N'" + us + "',2");
        }
        public void OffSecondSecurity(string us)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_UpdateType N'" + us + "',1");
        }
        public void Rename(string us, string newname)
        {
            string query = "EXEC USP_UpdateName '" + us + "','" + newname + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void EditKey(string us, string newkey)
        {
            string query = "EXEC USP_UpdateKey N'" + us + "',N'" + newkey + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void UpdateMail(string us, string mail)
        {
            string query = "EXEC USP_UpdateMail N'" + us + "',N'" + mail + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public bool KiemTraTK(string us)
        {
            string query = "SELECT * FROM ACCOUNT WHERE Username = '" + us + "'";
            DataTable check = DataProvider.Instance.ExecuteQuery(query);
            if (check != null && check.Rows.Count > 0) //Tài khoản đã tồn tại
                return true;
            else
                return false;
        }
    }
}
