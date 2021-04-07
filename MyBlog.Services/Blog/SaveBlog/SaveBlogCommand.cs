using MyBlog.Domain.Business;
using MyBlog.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.SaveBlog
{
    public class SaveBlogCommand : CommandBase<bool>
    {
        public BlogModel Blog { get; }
        public SaveBlogCommand(BlogModel blog)
        {
            Blog = blog;
        }
    }
}
