using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.DAL;
using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Services.User.GetRoles
{
    public class GetRolesHandler : IQueryHandler<GetRolesQuery, List<RoleModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _dbContext;
        public GetRolesHandler(IMapper mapper, ApplicationContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<List<RoleModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _dbContext.Roles.Where(t => t.UserId == request.UserId).ToListAsync();
            var rolesModel = _mapper.Map<List<RoleModel>>(roles);
            return rolesModel;
        }
    }
}
