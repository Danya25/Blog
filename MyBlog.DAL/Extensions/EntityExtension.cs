using Microsoft.EntityFrameworkCore;
using MyBlog.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.Extensions
{
    public static class EntityExtension
    {
        public static IQueryable<User> AddRoles(this IQueryable<User> query)
        {
            return query.Include(x => x.Roles);
        }
    }
}
