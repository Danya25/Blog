using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;
using System.Collections.Generic;

namespace MyBlog.Services.User.GetRoles
{
    public class GetRolesQuery : IQuery<List<RoleModel>>
    {
        public int UserId { get; }
        public GetRolesQuery(int userId)
        {
            UserId = userId;
        }
    }
}
