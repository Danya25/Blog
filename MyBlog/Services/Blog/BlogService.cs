using AutoMapper;
using MyBlog.Models;
using MyBlog.Models.Busines;
using MyBlog.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models.Entity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Services.Blog
{
    public sealed class BlogService : IBlogService
    {
        public ApplicationContext _context;
        public IMapper _mapper;
        public BlogService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteBlogById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogModel> GetBlogById(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(t => t.Id == id);

            var blogModel = _mapper.Map<BlogModel>(blog);

            return blogModel;
        }

        public async Task<List<BlogModel>> GetBlogs()
        {
            var blogs = await _context.Blogs.ToListAsync();
            var blogsModel = _mapper.Map<List<BlogModel>>(blogs);

            return blogsModel;
        }

        public async Task<bool> SaveBlog(BlogModel blog)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var blogEntity = _mapper.Map<Models.Entity.Blog>(blog);

                    await _context.Blogs.AddAsync(blogEntity);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();

                    return false;
                }
            }

        }
    }
}
