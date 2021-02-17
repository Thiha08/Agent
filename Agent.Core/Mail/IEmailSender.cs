﻿using System.Threading.Tasks;

namespace Agent.Core.Mail
{
    public interface IEmailSender
    {
        Task SendAsync(string from, string to, string subject, string body);
    }
}
