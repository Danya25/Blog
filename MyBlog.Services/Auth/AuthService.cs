﻿using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyBlog.Common.Models;
using MyBlog.DAL;
using MyBlog.DAL.Extensions;
using MyBlog.Domain.Business;
using MyBlog.Domain.Exceptions;
using MyBlog.Services.JWT;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MyBlog.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _dbContext;

        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;

        public AuthService(IJwtGenerator jwtGenerator, ApplicationContext dbContext, IMapper mapper)
        {
            _jwtGenerator = jwtGenerator;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserInfoModel> Login(UserModel userModel)
        {
            var user = await _dbContext.Users
                .AddRoles()
                .FirstOrDefaultAsync(t => t.Email == userModel.Email) ?? throw new UserNotFoundException("User not found!");

            var isCorrectPass = VerifyPassword(userModel.Password, user.Password, user.Salt);
            if (!isCorrectPass)
                throw new ValidationException("Password incorrect");

            var userInfo = new UserInfoModel
            {
                Email = user.Email,
                Token = _jwtGenerator.CreateToken(user),
                Username = user.DisplayName,
            };

            return userInfo;
        }
        public async Task<bool> Registration(UserModel userModel)
        {
            var isUserExist = await _dbContext.Users.AnyAsync(t => t.Email == userModel.Email);

            if (isUserExist) 
                throw new UserAlreadyExistsException("User already exists");

            var user = _mapper.Map<DAL.Entity.User>(userModel);

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var hashedPassword = GenerateSaltedHash(8, userModel.Password);
                    user.DisplayName = userModel.DisplayName;
                    user.Password = hashedPassword.Hash;
                    user.Salt = hashedPassword.Salt;


                    await _dbContext.Users.AddAsync(user);
                    await transaction.CommitAsync();
                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        private HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }
        private bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
    }
}
