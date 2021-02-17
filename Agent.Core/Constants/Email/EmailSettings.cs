namespace Agent.Core.Constants.Email
{
    public class EmailSettings : IEmailSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string SenderEmail { get; set; }

        public string Password { get; set; }
    }
}
