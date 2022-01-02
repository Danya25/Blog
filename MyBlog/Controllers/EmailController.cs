using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using MyBlog.Domain.DTO;
using MyBlog.Services.Email.SendEmail;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<MethodResult<bool>> SendEmail(EmailMessageDTO emailMessage)
        {
            var result = await _mediator.Send(new SendEmailCommand(emailMessage.Email, emailMessage.Subject, emailMessage.Message));
            return result.ToSuccessMethodResult();
        }
    }
}