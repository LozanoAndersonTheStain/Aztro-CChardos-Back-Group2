using System.Net;
using System.Net.Mail;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpServer = _configuration["Email:SmtpServer"] ?? throw new InvalidOperationException("SMTP server not configured");
            _smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
            _smtpUsername = _configuration["Email:Username"] ?? throw new InvalidOperationException("SMTP username not configured");
            _smtpPassword = _configuration["Email:Password"] ?? throw new InvalidOperationException("SMTP password not configured");
        }

        public async Task SendTravelPlanEmailAsync(string userEmail, string htmlContent)
        {
            using var client = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true
            };

            var message = new MailMessage
            {
                From = new MailAddress(_smtpUsername),
                Subject = "Tu Plan de Viaje - Amadeus",
                Body = htmlContent,
                IsBodyHtml = true
            };
            message.To.Add(userEmail);

            await client.SendMailAsync(message);
        }
    }
}