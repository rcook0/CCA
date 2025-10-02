using System.Net;
using System.Net.Mail;
namespace Infrastructure.Services;
public class EmailService
{
    private readonly IConfiguration _config;
    public EmailService(IConfiguration config) { _config = config; }
    public void SendEmail(string subject, string body)
    {
        var client = new SmtpClient(_config["Email:SmtpHost"], int.Parse(_config["Email:SmtpPort"] ?? "587"))
        {
            Credentials = new NetworkCredential(_config["Email:Username"], _config["Email:Password"]),
            EnableSsl = true
        };
        foreach (var recipient in _config["Email:AdminRecipients"].Split(','))
        {
            var msg = new MailMessage(_config["Email:From"], recipient.Trim(), subject, body);
            client.Send(msg);
        }
    }
}