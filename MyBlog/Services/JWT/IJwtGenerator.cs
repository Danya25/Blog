using MyBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services.JWT
{
    public interface IJwtGenerator
    {
        string CreateToken(User user);
    }
}
