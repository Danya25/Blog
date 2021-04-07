using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;

namespace MyBlog.Services.Blog.GetBlogById
{
    public class GetBlogByIdQuery : IQuery<DAL.Entity.Blog>
    {
        public int Id { get; }
        public GetBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}
