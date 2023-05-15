using ISpan.Project_02_DessertStory.Customer.Models.ApiKey;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System;

namespace ISpan.Project_02_DessertStory.Customer.Models.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _senderEmail;

        public EmailService(IOptions<GmailApiConfig> gmailApiConfig)
        {
            _senderEmail = "ispan.sweetshop@gmail.com"; // Replace with your email address

            var gmailApiConfigValue = gmailApiConfig.Value;

            _smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(gmailApiConfigValue.ClientId, gmailApiConfigValue.ClientSecret),
                EnableSsl = true
            };
        }

        public async Task SendAuthenticationEmailAsync(string recipientEmail, string authenticationUrl,string username)
        {
            var mailMessage = new MailMessage(_senderEmail, recipientEmail)
            {
                Subject = "[甜點物語]請驗證您的電子信箱",
                Body = $"<p>{username} 您好，</p><p>請點擊以下連結來驗證您的電子信箱。</p><p>驗證連結 :{authenticationUrl}</p>",
                IsBodyHtml = true
            };

            await _smtpClient.SendMailAsync(mailMessage);
        }

    }
}
