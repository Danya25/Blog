using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;

namespace MyBlog.Services.Blog.GetBlogById
{
    public class GetBlogByIdQuery : IQuery<BlogModel>
    {
        public int BlogId { get; }
        public int? UserId { get; }
        public GetBlogByIdQuery(int blogId, int? userId)
        {
            BlogId = blogId;
            UserId = userId;
        }
    }
}
