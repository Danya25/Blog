using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.DAL.Entity
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
