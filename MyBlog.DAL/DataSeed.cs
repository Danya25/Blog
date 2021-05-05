using Microsoft.AspNetCore.Identity;
using MyBlog.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    public sealed class DataSeed
    {
        public static async Task InitializeAsync(ApplicationContext dbContext)
        {
            var adminName = "admin";
            var adminPass = "_Aa123456";

            if (!dbContext.Users.Any(t => t.DisplayName == adminName))
            {
                var pass = GenerateSaltedHash(8, adminPass);
                var admin = new User { DisplayName = adminName, Email = "admin@mail.ru", Password = pass.Hash, Salt = pass.Salt };
                var adminEntityInfo = await dbContext.Users.AddAsync(admin);

                await dbContext.SaveChangesAsync();

                var roles = new List<Role>()
                {
                    new Role { Name = Roles.Admin, UserId = adminEntityInfo.Entity.Id },
                    new Role { Name = Roles.Moderator, UserId = adminEntityInfo.Entity.Id },
                    new Role { Name = Roles.User, UserId = adminEntityInfo.Entity.Id }
                };

                await dbContext.Roles.AddRangeAsync(roles);

                await dbContext.SaveChangesAsync();
            }
        }

        private static (string Hash, string Salt) GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            (string Hash, string Salt) hashSalt = (hashPassword, salt);
            return hashSalt;
        }
    }
}
