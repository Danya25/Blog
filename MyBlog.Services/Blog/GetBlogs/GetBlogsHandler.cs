using Microsoft.EntityFrameworkCore;
using MyBlog.DAL;
using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetBlogs
{
    public class GetBlogsHandler : IQueryHandler<GetBlogsQuery, List<DAL.Entity.Blog>>
    {
        private readonly ApplicationContext _dbContext;

        public GetBlogsHandler(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DAL.Entity.Blog>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Blogs.ToListAsync();
        }
    }
}
