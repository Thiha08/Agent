using Agent.Core.Args;
using Agent.Core.BackgroundJobs;
using Agent.Core.Interfaces;
using Agent.Core.Mail;
using System.Threading.Tasks;

namespace Agent.Infrastructure.BackgroundServices
{
    public class EmailBackgroundService : BackgroundJob<EmailArgs>, IBackgroundService
    {
        private readonly IEmailSender _emailSender;

        public EmailBackgroundService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public override async Task ExecuteAsync(EmailArgs args)
        {
            await _emailSender.SendAsync(args.From, args.To, args.Subject, args.Body);
        }
    }
}
