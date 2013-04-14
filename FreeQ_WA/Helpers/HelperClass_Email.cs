using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace FreeQ_WA.Helpers
{
    public class HelperClass_Email
    {
        public static void SendEmail(string emailAddress, string emailTitle, string emailBody)
        {
            Mail email = new Mail("Quddle", "noreply@quddle.org", emailAddress, emailAddress, emailTitle, emailBody, true, false);
            email.Send();
        }
    }

    public class Mail
    {
        private System.Net.Mail.MailMessage _mail = new System.Net.Mail.MailMessage();
        
        public Mail(string fromName, string fromMail, string toName, string toMail, string subject, string body, bool isHtml, bool highPriority)
        {
            this._mail.Subject = subject;
            this._mail.Body = body;
            this._mail.From = new System.Net.Mail.MailAddress(fromMail, fromName);
            this._mail.To.Add(new System.Net.Mail.MailAddress(toMail, toName));
            this._mail.IsBodyHtml = isHtml;
            this._mail.BodyEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            this._mail.SubjectEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            if (highPriority) this._mail.Priority = System.Net.Mail.MailPriority.High;
        }
        
        public bool Send()
        {
            try
            {
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.qudlle.org"); // Mettre le serveur smtp ici

                //to authenticate we set the username and password properites on the SmtpClient
                smtp.Credentials = new NetworkCredential("contact@snipeagent.com", "xx");

                smtp.Send(this._mail);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
