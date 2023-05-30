using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace AlAnon.Helper
{
    public class MailKitEmailSender : IEmailSender
    {
        public MailKitEmailSenderOptions _options { get; set; }
        public MailKitEmailSender(IOptions<MailKitEmailSenderOptions> options)
        {
            _options = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(email, subject, message);
        }

        public Task Execute(string to, string subject, string message)
        {
            // create message
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_options.Sender_EMail);
            if (!string.IsNullOrEmpty(_options.Sender_Name))
                email.Sender.Name = _options.Sender_Name;
            email.From.Add(email.Sender);
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };

            // send email
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_options.Host_Address, _options.Host_Port, _options.Host_SecureSocketOptions);
                smtp.Authenticate(_options.Host_Username, _options.Host_Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            return Task.FromResult(true);
        }
    }
}
