using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.Commands;
using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.Blog.GetBlogById
{
    public class GetBlogByIdHandler : IQueryHandler<GetBlogByIdQuery, BlogModel>
    {
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;
        public GetBlogByIdHandler(ApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BlogModel> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(t => t.Id == request.Id);

            return _mapper.Map<BlogModel>(blog);
        }
    }
}
