﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSSL { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
        {
            Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password),
            EnableSsl = _emailSettings.EnableSSL
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.UserName),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(email);

        return client.SendMailAsync(mailMessage);
    }
}
