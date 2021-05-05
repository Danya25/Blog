using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.DTO;
using MyBlog.Models;
using MyBlog.Services.Blog;
using MyBlog.Services.Blog.GetBlogById;
using MyBlog.Services.Blog.GetBlogs;
using MyBlog.Services.Blog.GetBlogsWithPagination;
using MyBlog.Services.Blog.GetFiveNewestBlogs;
using MyBlog.Services.Blog.SaveBlog;
using System;
using System.Collections.Generic;
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
            try
            {
                var blogs = await _mediator.Send(new GetBlogsQuery());
                var blogsDto = _mapper.Map<List<BlogDTO>>(blogs);

                return blogsDto.ToSuccessMethodResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<List<BlogDTO>>();
            }
        }

        [HttpGet("GetBlogsPagination")]
        public async Task<MethodResult<List<BlogDTO>>> GetBlogs([FromQuery]QueryPagination query)
        {
            try
            {
                var blogs = await _mediator.Send(new GetBlogsWithPaginationQuery(query.CurrentCount, query.PageSize));
                var blogsDto = _mapper.Map<List<BlogDTO>>(blogs);

                return blogsDto.ToSuccessMethodResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<List<BlogDTO>>();
            }
        }

        [HttpGet("GetBlogById/{id:int:min(0)}")]
        public async Task<MethodResult<BlogDTO>> GetBlogById(int id)
        {
            try
            {
                var blog = await _mediator.Send(new GetBlogByIdQuery(id));
                var blogDto = _mapper.Map<BlogDTO>(blog);

                return blogDto.ToSuccessMethodResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<BlogDTO>();
            }
        }

        [HttpGet("GetFiveNewestBlogs")]
        public async Task<MethodResult<List<BlogDTO>>> GetFiveNewestBlogs()
        {
            try
            {
                var blogs = await _mediator.Send(new GetFiveNewestBlogsQuery());
                var blogsDto = _mapper.Map<List<BlogDTO>>(blogs);

                return blogsDto.ToSuccessMethodResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<List<BlogDTO>>();
            }
            throw new Exception();
        }

        [HttpGet("DeleteBlogById/{id:int:min(0)}")]
        public async Task<MethodResult<bool>> DeleteBlogById(int id)
        {
            return true.ToSuccessMethodResult();
        }

        [HttpGet("TestAuthorizeUser")]
        [Authorize(Roles = Roles.User)]
        public async Task<bool> TestAuthorizeUser()
        {
            return true;
        }

        [HttpGet("TestAuthorizeAdmin")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<bool> TestAuthorizeAdmin()
        {
            return true;
        }

        [HttpGet("TestAuthorize")]
        [Authorize]
        public async Task<bool> TestAuthorize()
        {
            return true;
        }

    }
}
