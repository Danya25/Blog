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
        public string Username { get; }
        public SaveBlogCommand(BlogModel blog, string username)
        {
            Blog = blog;
            Username = username;
        }
    }
}
