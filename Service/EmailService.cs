using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SumitPortfolio.Web.Interfaces
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _log;
        public EmailService(IConfiguration config, ILogger<EmailService> log)
        {
            _config = config;
            _log = log;
        }
        #region

        private void Send(string ToEmailId, bool isBccToAdmin, string bcc, string subject, string mailBody)
        {
            // var apiKey = _config["SendGridSetting:ApiKey"];
            // var client = new SendGridClient(apiKey);
            // var from = new EmailAddress("QAI@theqai.org", "FeedBack System Support Team");
            // var to = new EmailAddress(ToEmailId);
            // var plainTextContent = mailBody;
            // var htmlContent = mailBody;
            // var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);

            // client.SendEmailAsync(msg).Wait();



            string senderEmail = "sks13122003@gmail.com";
            // string senderEmail = "sks13072003@gmail.com";
            string senderPassword = "qfat iogh sgvc kkwp";


            MailMessage mail = new MailMessage(senderEmail, ToEmailId);
            mail.Subject = subject;
            mail.Body = mailBody;
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);

        }
        #endregion

        public bool SendEmailWithoutBcc(string to_email, string subject, string body)
        {
            Send(to_email, false, "", subject, body);
            return true;
        }

    }
}
