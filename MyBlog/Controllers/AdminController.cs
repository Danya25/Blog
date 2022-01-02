using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Common;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.DTO;
using MyBlog.Services.Blog.SaveBlog;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdminController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("SaveBlog")]
        public async Task<MethodResult<bool>> SaveBlog(BlogDTO blog)
        {
            var username = User.Claims.First(t => t.Type == ClaimTypes.Name).Value;
            var blogModel = _mapper.Map<BlogModel>(blog);
            var result = await _mediator.Send(new SaveBlogCommand(blogModel, username));
            return result.ToSuccessMethodResult();
        }
    }
}
