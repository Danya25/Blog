using MyBlog.Models.Busines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog
{
    public interface IBlogService
    {
        Task<bool> SaveBlog(BlogModel blog);
        Task<bool> DeleteBlogById(int id);
        Task<List<BlogModel>> GetBlogs();
        Task<BlogModel> GetBlogById(int id);
        Task<List<BlogModel>> GetFiveNewestBlogs();
    }
}
