namespace do_an_ck
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string suject, string message);
    }
}
