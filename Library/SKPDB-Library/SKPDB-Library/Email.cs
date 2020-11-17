using System;
using System.Net;
using System.Net.Mail;

namespace SKPDB_Library
{
    class Email
    {
        private SmtpClient smtpServer;
        private string clientmail = "NoReply@projektdb.zbc.dk";

        public Email()
        {

            smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential(clientEmail, clientPassword);
            smtpServer.EnableSsl = true;
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
