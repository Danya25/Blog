using MyBlog.Domain.Business;
using MyBlog.Services.Blog.SaveBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyBlog.Tests
{
    public class BlogServiceTests
    {
        public BlogServiceTests()
        {
            var host = Host
        }

        [Fact]
        public void TryToSaveBlog()
        {
            var blog = new BlogModel
            {
                ShortDescription = "Test",
                DateOfCreation = DateTime.Now,
                Description = "Desc",
                Title = "Title",
                PhotoUrl = "test.com",
                Username = "MyUser"
            };
            var command = new SaveBlogCommand(blog, "Me");


        }
    }
}
