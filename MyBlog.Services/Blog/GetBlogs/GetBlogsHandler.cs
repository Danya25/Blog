using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetBlogs
{
    public class GetBlogsHandler : IQueryHandler<GetBlogsQuery, List<BlogModel>>
    {
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public GetBlogsHandler(ApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<BlogModel>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _dbContext.Blogs.ToListAsync();
            return _mapper.Map<List<BlogModel>>(blogs);
        }
    }
}
