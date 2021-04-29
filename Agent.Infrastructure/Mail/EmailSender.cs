using Agent.Core.Constants.Email;
using Agent.Core.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Threading.Tasks;

namespace Agent.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly IEmailSettings _emailSettings;

        public EmailSender(ILogger<EmailSender> logger, IEmailSettings emailSettings)
        {
            _logger = logger;
            _emailSettings = emailSettings;
        }

        public async Task SendAsync(string from, string to, string subject, string body)
        {
            _logger.LogInformation("Email sending started");
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(from));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            //await client.AuthenticateAsync(_emailSettings.SenderEmail, "wrong");
            await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            _logger.LogInformation($"Email sent to {message.To}");
        }
    }
}
