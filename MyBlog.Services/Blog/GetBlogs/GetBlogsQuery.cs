using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetBlogs
{
    public class GetBlogsQuery : IQuery<List<DAL.Entity.Blog>>
    {
    }
}
