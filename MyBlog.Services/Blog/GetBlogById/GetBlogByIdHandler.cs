using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.Commands;
using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetBlogById
{
    public class GetBlogByIdHandler : IQueryHandler<GetBlogByIdQuery, DAL.Entity.Blog>
    {
        private readonly ApplicationContext _dbContext;

        public GetBlogByIdHandler(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DAL.Entity.Blog> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(t => t.Id == request.Id);

            return blog;
        }
    }
}
