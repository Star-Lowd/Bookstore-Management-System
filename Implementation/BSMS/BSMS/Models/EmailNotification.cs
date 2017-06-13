using BSMS.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BSMS.Models
{
    public class EmailNotification
    {
        private const String BSMS_EMAIL = "olaoluwase03975@fpt.edu.vn";
        private const String BSMS_EMAIL_PASS = "OlasehindEezekiel11";
        
        internal static void ForgetPassword(string email, String hashCode, int userID)
        {
            String ResetPasswordMessage = String.Format("you have requested to reset your password<br />"+
                "Click here <a href='http://localhost:52350/Authentication/ResetPassword?hash={0}&userID={1}'> Reset Password </a> to reset your password",
                hashCode, userID);
            SendEmail(email, ResetPasswordMessage, "Reset Email");
        }

        private static void SendEmail(String email, String Message, String title)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(BSMS_EMAIL);
            mail.To.Add(email);
            mail.Subject = title;
            mail.Body = Message;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(BSMS_EMAIL, BSMS_EMAIL_PASS);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}