using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetBlogsWithPagination
{
    public class GetBlogsWithPaginationHandler : IQueryHandler<GetBlogsWithPaginationQuery, List<BlogModel>>
    {
        private readonly ApplicationContext _appContext;
        private readonly IMapper _mapper;
        public GetBlogsWithPaginationHandler(ApplicationContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
        public async Task<List<BlogModel>> Handle(GetBlogsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _appContext.Blogs.OrderBy(t=> t.DateOfCreation).Skip(request.CurrentCount).Take(request.PageSize).ToListAsync();
            var blogsModel = _mapper.Map<List<BlogModel>>(blogs);
            return blogsModel;
        }
    }
}
