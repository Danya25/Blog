using MyBlog.Domain.Commands;

namespace MyBlog.Services.Email.SendEmail
{
    public class SendEmailCommand : CommandBase<bool>
    {
        public string Email { get; }
        public string Subject { get; }
        public string Message { get; }

        public SendEmailCommand(string email, string subject, string message)
        {
            Email = email;
            Subject = subject;
            Message = message;
        }

    }
}