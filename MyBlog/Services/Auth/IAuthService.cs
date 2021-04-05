using MyBlog.Models.Busines;
using MyBlog.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services.Auth
{
    public interface IAuthService
    {
        public Task<UserInfoModel> Login(UserModel user);
    }
}
