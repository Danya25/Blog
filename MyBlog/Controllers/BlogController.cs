using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using MyBlog.Domain.DTO;
using MyBlog.Models;
using MyBlog.Services.Blog.GetBlogById;
using MyBlog.Services.Blog.GetBlogs;
using MyBlog.Services.Blog.GetBlogsWithPagination;
using MyBlog.Services.Blog.GetFiveNewestBlogs;
using MyBlog.Services.Blog.LikeBlog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public ILogger<BlogController> _logger;
        public IMapper _mapper;

        private readonly IMediator _mediator;

        public BlogController(ILogger<BlogController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("GetBlogs")]
        public async Task<MethodResult<List<BlogDTO>>> GetBlogs()
        {
            var blogs = await _mediator.Send(new GetBlogsQuery());
            var blogsDto = _mapper.Map<List<BlogDTO>>(blogs);

            return blogsDto.ToSuccessMethodResult();
        }

        [HttpGet("GetBlogsPagination")]
        public async Task<MethodResult<List<BlogDTO>>> GetBlogs([FromQuery]QueryPagination query)
        {
            var blogs = await _mediator.Send(new GetBlogsWithPaginationQuery(query.CurrentCount, query.PageSize));
            var blogsDto = _mapper.Map<List<BlogDTO>>(blogs);

            return blogsDto.ToSuccessMethodResult();
        }

        [HttpGet("GetBlogById/{id:int:min(0)}")]
        public async Task<MethodResult<BlogDTO>> GetBlogById(int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(t => t.Type == "UserId")?.Value;
            int? userId = userIdClaim is null ? null : int.Parse(User.Claims.First(t => t.Type == "UserId").Value);

            var blog = await _mediator.Send(new GetBlogByIdQuery(id, userId));
            var blogDto = _mapper.Map<BlogDTO>(blog);

            return blogDto.ToSuccessMethodResult();
        }

        [HttpGet("GetFiveNewestBlogs")]
        public async Task<MethodResult<List<BlogDTO>>> GetFiveNewestBlogs()
        {
            var blogs = await _mediator.Send(new GetFiveNewestBlogsQuery());
            var blogsDto = _mapper.Map<List<BlogDTO>>(blogs);

            return blogsDto.ToSuccessMethodResult();
        }

        [HttpPost("LikeBlog")]
        [Authorize]
        public async Task<MethodResult<bool>> LikeBlog(BlogLikeDTO likeInfo)
        {
            var userId = int.Parse(User.Claims.First(t => t.Type == "UserId").Value);
            var result = await _mediator.Send(new LikeBlogCommand(userId, likeInfo.BlogId, likeInfo.LikeStatus));
            return result.ToSuccessMethodResult();
        }

    }
}
