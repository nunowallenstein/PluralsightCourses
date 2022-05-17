namespace CityInfo.API.Services
{
    public class CloudMailService : ILocalMailService
    {

        private readonly string _mailTo=string.Empty;
        private readonly string _mailFrom=string.Empty;
        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string body)
        {
            Console.WriteLine($"mailFrom:{_mailFrom}, mailTo: {_mailTo} " +
                $" with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
        }

    }
}
