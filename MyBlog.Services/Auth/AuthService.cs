using Microsoft.AspNetCore.Identity;
using MyBlog.DAL.Entity;
using MyBlog.Domain.Business;
using MyBlog.Services.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<UserInfoModel> Login(UserModel userModel)
        {
            var user = await _userManager.FindByEmailAsync(userModel.Email) ?? throw new Exception("User not exist!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, userModel.Password, false);
            if (!result.Succeeded)
                throw new Exception("Login or password incorrect!");

            var userInfo = new UserInfoModel
            {
                Email = user.Email,
                Id = user.Id,
                Token = _jwtGenerator.CreateToken(user),
                Username = user.UserName
            };

            return userInfo;
        }
    }
}
