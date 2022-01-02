using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MyBlog.Domain.Commands;

namespace MyBlog.Services.Email.SendEmail
{
    public class SendEmailHandler : ICommandHandler<SendEmailCommand, bool>
    {
        public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "RATATABlog"));
            emailMessage.To.Add(new MailboxAddress("", request.Email));
            emailMessage.Subject = request.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = request.Message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", 465, true);
            await client.AuthenticateAsync("ivan.cher1988@mail.ru", "QQQq123qQQQ");
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);

            return true;
        }
    }
}