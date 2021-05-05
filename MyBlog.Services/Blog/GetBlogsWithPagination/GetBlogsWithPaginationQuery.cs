using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetBlogsWithPagination
{
    public class GetBlogsWithPaginationQuery : IQuery<List<BlogModel>>
    {
        public int CurrentCount { get; }
        public int PageSize { get; }

        public GetBlogsWithPaginationQuery(int currentCount, int pageSize)
        {
            CurrentCount = currentCount;
            PageSize = pageSize;
        }
    }
}
