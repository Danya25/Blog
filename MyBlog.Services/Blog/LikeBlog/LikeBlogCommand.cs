using MyBlog.Domain.Commands;

namespace MyBlog.Services.Blog.LikeBlog
{
    public class LikeBlogCommand : CommandBase<bool>
    {
        public int UserId { get; }
        public int BlogId { get; }
        public bool LikeStatus { get; }
        public LikeBlogCommand(int userId, int blogId, bool likeStatus)
        {
            UserId = userId;
            BlogId = blogId;
            LikeStatus = likeStatus;
        }
    }
}
