namespace Agent.Core.Constants.Email
{
    public interface IEmailSettings
    {
        string Host { get; set; }

        int Port { get; set; }

        string SenderEmail { get; set; }

        string Password { get; set; }
    }
}
