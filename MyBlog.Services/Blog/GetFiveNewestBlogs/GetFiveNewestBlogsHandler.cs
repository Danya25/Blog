using Microsoft.EntityFrameworkCore;
using MyBlog.DAL;
using MyBlog.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetFiveNewestBlogs
{
    public class GetFiveNewestBlogsHandler : IQueryHandler<GetFiveNewestBlogsQuery, List<DAL.Entity.Blog>>
    {
        private readonly ApplicationContext _dbContext;
        public GetFiveNewestBlogsHandler(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DAL.Entity.Blog>> Handle(GetFiveNewestBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Blogs.OrderByDescending(t => t.DateOfCreation).Take(5).ToListAsync();
        }
    }
}
