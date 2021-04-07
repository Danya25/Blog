using AutoMapper;
using MyBlog.DAL;
using MyBlog.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.SaveBlog
{
    public class SaveBlogHandler : ICommandHandler<SaveBlogCommand, bool>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public SaveBlogHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SaveBlogCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var blog = _mapper.Map<DAL.Entity.Blog>(request.Blog);

                    await _context.Blogs.AddAsync(blog);
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
