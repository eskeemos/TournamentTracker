using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

namespace Logic.DataHelpers
{
    public static class EmailLogic // x
    {
        public static void SendEmail(string to, string subject, string body)
        {
            SendEmail(new List<string> {to}, new List<string> { }, subject, body );
        }
        public static void SendEmail(List<string> to, List<string> bcc, string subject, string body)
        {
            MailAddress fromMail = new MailAddress(ConfigurationManager.AppSettings["senderEmail"], ConfigurationManager.AppSettings["senderDisplayName"]);

            MailMessage mail = new MailMessage();

            foreach (string email in to)
            {
                mail.To.Add(email); 
            }
            foreach (string email in bcc)
            {
                mail.Bcc.Add(email);
            }

            mail.From = fromMail;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();

            client.Send(mail);
        }
    }
}
