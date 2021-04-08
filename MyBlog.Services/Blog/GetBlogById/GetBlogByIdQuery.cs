using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;

namespace MyBlog.Services.Blog.GetBlogById
{
    public class GetBlogByIdQuery : IQuery<BlogModel>
    {
        public int Id { get; }
        public GetBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}
