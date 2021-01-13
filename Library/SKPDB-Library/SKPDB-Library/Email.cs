using System;
using System.Net;
using System.Net.Mail;

namespace SKPDB_Library
{
    internal class Email
    {
        private SmtpClient smtpServer;
        private string clientmail = "NoReply@projektdb.skp.dk";

        public Email()
        {

            smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("skprgopg@gmail.com", "Kode123!");
            smtpServer.EnableSsl = true;
        }
        /// <summary>
        /// Sends and email to customer
        /// </summary>
        /// <param name="customerEmail">The email you want to send to</param>
        public void SendEmail(string customerEmail, string subject, string message)
        {
            MailMessage mail = CreateEmail(customerEmail, subject, message);
            smtpServer.Send(mail);
            mail.Dispose();
        }

        /// <summary>
        /// Create a mailmessage
        /// </summary>
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
