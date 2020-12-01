using System;
using System.Net;
using System.Net.Mail;

namespace SKPDB_Library
{
    public class Email
    {
        private SmtpClient smtpServer;
        private string clientmail = "NoReply@projektdb.zbc.dk";

        public Email()
        {

            smtpServer = new SmtpClient("10.108.48.80");
            smtpServer.Port = 25;
            smtpServer.Credentials = new NetworkCredential("admin", "Kode123");
            smtpServer.EnableSsl = false;
        }

        public void SendEmail(string customerEmail, string subject, string message)
        {
            MailMessage mail = CreateEmail(customerEmail, subject, message);
            smtpServer.Send(mail);
            mail.Dispose();
        }

        private MailMessage CreateEmail(string customerEmail, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(clientmail);
            mail.To.Add(new MailAddress(customerEmail));
            mail.Subject = subject;
            mail.Body = message;
            return mail;
        }
    }
}
