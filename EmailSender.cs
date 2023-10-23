using System.Net;
using System.Net.Mail;
using System;
using System.Threading.Tasks;
namespace do_an_ck
{
    public class EmailSender: IEmailSender
    {
        public Task SendEmailAsync(string email, string suject, string message) 
        {
            return Task.CompletedTask;
        }
    }
}
