using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace EvoWeb.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Фирма Эволюция", "evoweb.qwerty@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
             
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("evoweb.qwerty", "ktvugpfzbzmtudjs");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}