using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetFiveNewestBlogs
{
    public class GetFiveNewestBlogsQuery : IQuery<List<DAL.Entity.Blog>>
    {
    }
}
