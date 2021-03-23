using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using MyBlog.Models.Busines;
using MyBlog.Models.DTO;
using MyBlog.Services.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public ILogger<BlogController> _logger;
        public IBlogService _blogService;
        public IMapper _mapper;

        public BlogController(ILogger<BlogController> logger, IBlogService blogService, IMapper mapper)
        {
            _logger = logger;
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<MethodResult<bool>> SaveBlog(BlogDTO blog)
        {
            try
            {
                var blogModel = _mapper.Map<BlogModel>(blog);
                var result = await _blogService.SaveBlog(blogModel);
                return result.ToSuccessMethodResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<bool>();
            }
        }

        [HttpGet]
        public async Task<MethodResult<List<BlogDTO>>> GetBlogs()
        {
            try
            {
                var blogsModel = await _blogService.GetBlogs();
                var blogs = _mapper.Map<List<BlogDTO>>(blogsModel);
                return blogs.ToSuccessMethodResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<List<BlogDTO>>();
            }
        }

        [HttpGet("{id:int:min(0)}")]
        public async Task<MethodResult<BlogDTO>> GetBlogById(int id)
        {
            try
            {
                var blogModel = await _blogService.GetBlogById(id);
                var blog = _mapper.Map<BlogDTO>(blogModel);
                return blog.ToSuccessMethodResult();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<BlogDTO>();
            }
        }

        [HttpGet("{id:int:min(0)}")]
        public async Task<MethodResult<bool>> DeleteBlogById(int id)
        {
            try
            {
                var result = await _blogService.DeleteBlogById(id);
                return result.ToSuccessMethodResult();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<bool>();
            }
        }


    }
}
