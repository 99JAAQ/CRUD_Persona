using Microsoft.Extensions.Options;
using Base.Proyecto.Common.Dto;
using Base.Proyecto.Common.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Base.Proyecto.Common.Utils
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _emailSettings;

        public EmailService(IOptions<EmailSetting> setting)
        {
            _emailSettings = setting.Value;
        }

        public void SendEmail(string emailDestionation, string title, string body)
        {
            string host = _emailSettings.Host;
            int port = _emailSettings.Port;
            string email = _emailSettings.Email;
            string password = _emailSettings.Password;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(email);
                mail.To.Add(emailDestionation);
                mail.Subject = title;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(email, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}