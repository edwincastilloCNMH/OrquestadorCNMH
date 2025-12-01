using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Domain.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void Send(string toEmail, string subject, string htmlBody)
        {
            var settings = _config.GetSection("EmailSettings");

            string smtpServer = settings["SmtpServer"];
            int port = int.Parse(settings["Port"]);
            bool enableSsl = bool.Parse(settings["EnableSsl"]);
            string senderEmail = settings["SenderEmail"];
            string senderName = settings["SenderName"];
            string username = settings["Username"];
            string password = settings["Password"];

            var message = new MailMessage();
            message.From = new MailAddress(senderEmail, senderName);
            message.To.Add(toEmail);
            message.Subject = subject;
            message.Body = htmlBody;
            message.IsBodyHtml = true;

            using (var client = new SmtpClient(smtpServer, port))
            {
                client.Credentials = new NetworkCredential(username, password);
                client.EnableSsl = enableSsl;
                client.Send(message);
            }
        }
    }
}
