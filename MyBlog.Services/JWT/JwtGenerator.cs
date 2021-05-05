using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBlog.Common.Models;
using MyBlog.DAL;
using MyBlog.DAL.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBlog.Services.JWT
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SymmetricKey _symmetricKey;
        public JwtGenerator(IOptions<SymmetricKey> key)
        {
            _symmetricKey = key.Value;
        }

        public string CreateToken(DAL.Entity.User user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_symmetricKey.Key));

            var claims = new List<Claim>() 
            { 
                new Claim("UserId", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.DisplayName)
            };
            foreach(var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
