using System.Net;
using System.Net.Mail;

namespace Server.DAO
{
    public class SendMail
    {
        //field
        #region Khai báo
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFromAddress = env.Security.sEmailFromAddress; //Tài khoản email nguồn
        static string password = env.Security.sPassword;//PassWord email nguồn
        //Email nguồn cần bắt buộc bật quyền truy cập từ các ứng dụng khác
        string emailToAddress;
        string code;
        //property
        public string EmailToAddress { get => emailToAddress; set => emailToAddress = value; }
        public string Code { get => code; set => code = value; }
        //Constructors
        public SendMail(string sToEmail, string sCode)
        {
            EmailToAddress = sToEmail;
            Code = sCode;
        }
        #endregion
        //method
        public void SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = "Hello";
                mail.Body = "Hello, Thank you for using my app <br /> This is your code: <b>" + code + "<b>.";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}

