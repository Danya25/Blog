using AutoMapper;
using MyBlog.DAL;
using MyBlog.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.LikeBlog
{
    public class LikeBlogHandler : ICommandHandler<LikeBlogCommand, bool>
    {
        private readonly ApplicationContext _context;

        public LikeBlogHandler( ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(LikeBlogCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (!request.LikeStatus)
                    {
                        await _context.BlogLikes.AddAsync(new DAL.Entity.BlogLike { BlogId = request.BlogId, UserId = request.UserId });
                    }
                    else
                    {
                        _context.BlogLikes.Remove(new DAL.Entity.BlogLike { BlogId = request.BlogId, UserId = request.UserId });
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
