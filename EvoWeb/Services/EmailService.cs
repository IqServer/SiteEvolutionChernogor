﻿using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace EvoWeb.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message) // многопоток
        {
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "evoweb.qwerty@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
             
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 587, SecureSocketOptions.StartTls); // многопоток
                await client.AuthenticateAsync("evoweb.qwerty", "ktvugpfzbzmtudjs"); // многопоток
                await client.SendAsync(emailMessage); // многопоток
                await client.DisconnectAsync(true); // многопоток
            }
        }
    }
}