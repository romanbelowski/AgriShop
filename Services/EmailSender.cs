using System.Net;
using System.Net.Mail;
using WSLab.Services;

namespace WSLab.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string name, string email, string subject, string message)
        {
            var mail = "your.email@live.com";
            var pw = "your password";

            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject,
                                message
                                ));



        }
    }
}
