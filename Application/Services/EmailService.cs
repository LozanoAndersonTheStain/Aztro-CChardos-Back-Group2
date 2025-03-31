using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class EmailService(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly string _smtpServer = Environment.GetEnvironmentVariable("MAIL_SMTP_SERVER") ?? "smtp.gmail.com";
        private readonly int _smtpPort = int.Parse(Environment.GetEnvironmentVariable("MAIL_SMTP_PORT") ?? "587");
        private readonly string _smtpUsername = Environment.GetEnvironmentVariable("MAIL_USERNAME") ??
                throw new InvalidOperationException("SMTP username not configured");
        private readonly string _smtpPassword = Environment.GetEnvironmentVariable("APP_PASSWORD") ??
                throw new InvalidOperationException("SMTP password not configured");

        public async Task SendTravelPlanEmailAsync(string userEmail, string htmlContent)
        {
            try
            {
                using var client = new SmtpClient(_smtpServer, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = true
                };

                var message = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = GetPersonalizedSubject("Tu Plan de Viaje - Amadeus"),
                    Body = htmlContent,
                    IsBodyHtml = true
                };
                message.To.Add(userEmail);

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error sending email: {ex.Message}", ex);
            }
        }

        private string GetPersonalizedSubject(string baseSubject)
        {
            var now = DateTime.Now.TimeOfDay;
            string greeting;

            if (now >= TimeSpan.FromHours(6) && now < TimeSpan.FromHours(12))
            {
                greeting = "Buenos días";
            }
            else if (now >= TimeSpan.FromHours(12) && now < TimeSpan.FromHours(18))
            {
                greeting = "Buenas tardes";
            }
            else
            {
                greeting = "Buenas noches";
            }

            return $"{greeting}: {baseSubject}";
        }
    }
}