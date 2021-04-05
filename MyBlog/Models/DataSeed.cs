using Microsoft.AspNetCore.Identity;
using MyBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public sealed class DataSeed
    {
        public static async Task InitializeAsync(UserManager<User> userManager)
        {
            var adminName = "admin";
            var adminPass = "_Aa123456";
            if (await userManager.FindByNameAsync(adminName) == null)
            {
                User admin = new User { Email = "admin@mail.ru", UserName = adminName, DisplayName = adminName };
                User user = new User { Email = "user@mail.ru", UserName = "user", DisplayName = "user" };

                await userManager.CreateAsync(admin, adminPass);
                await userManager.CreateAsync(user, adminPass);
            }
        }
    }
}
