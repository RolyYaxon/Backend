using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

public class EmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _fromEmail;

    public EmailService(SmtpClient smtpClient, IConfiguration configuration)
    {
        _smtpClient = smtpClient;
        _fromEmail = configuration["Smtp:UserName"];
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var mailMessage = new MailMessage(_fromEmail, toEmail, subject, body);
        mailMessage.IsBodyHtml = true;  // Permite el envío de HTML en el cuerpo del correo
        await _smtpClient.SendMailAsync(mailMessage);
    }
}
