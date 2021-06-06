using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.DTO;
using MyBlog.Services.Blog.SaveBlog;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdminController(ILogger<AdminController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("SaveBlog")]
        public async Task<MethodResult<bool>> SaveBlog(BlogDTO blog)
        {
            try
            {
                var username = User.Claims.First(t => t.Type == ClaimTypes.Name).Value;
                var blogModel = _mapper.Map<BlogModel>(blog);
                var result = await _mediator.Send(new SaveBlogCommand(blogModel, username));
                return result.ToSuccessMethodResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<bool>();
            }
        }
    }
}
