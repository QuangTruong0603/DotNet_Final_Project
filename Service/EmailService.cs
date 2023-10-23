using MimeKit;
using MailKit;
using Microsoft.Extensions.Options;

using System.Net;
using System.Net.Mail;

namespace do_an_ck.Service
{
    public class EmailService
    {
        /*private readonly SmtpSettings _smtpSettings;
        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", "52100941@student.tdtu.edu.vn"));
            message.To.Add(new MailboxAddress("abc", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.example.com",587);
                await client.AuthenticateAsync("52100941@student.tdtu.edu.vn", "truonghoctdtu");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }*/
        public bool SendEMail(string to, string subject, string body, string attachFile)
        {
            try
            {
                MailMessage message = new MailMessage("52100941@student.tdtu.edu.vn", to, subject, body);
                using (var client = new SmtpClient("smtp-mail.outlook.com", 587))
                {
                    client.EnableSsl = true;
                    if (!string.IsNullOrEmpty(attachFile))
                    {
                        Attachment attachment = new Attachment(attachFile);
                        message.Attachments.Add(attachment);
                    }
                    NetworkCredential networkCredential = new NetworkCredential("52100941@student.tdtu.edu.vn", "truonghoctdtu");
                    client.UseDefaultCredentials = false;
                    client.Credentials = networkCredential;
                    client.Send(message);

                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        
    }
}
