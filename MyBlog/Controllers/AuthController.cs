using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using MyBlog.Models.Busines;
using MyBlog.Models.DTO;
using MyBlog.Models.Entity;
using MyBlog.Services.Auth;
using MyBlog.Services.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthController(IAuthService authService, IMapper mapper, ILogger<AuthController> logger)
        {
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<MethodResult<UserInfoDTO>> Login(UserDTO user)
        {
            try
            {
                var userModel = _mapper.Map<UserModel>(user);
                var userInfo = await _authService.Login(userModel);
                var userInfoDto = _mapper.Map<UserInfoDTO>(userInfo);

                return userInfoDto.ToSuccessMethodResult();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.ToErrorMethodResult<UserInfoDTO>();
            }
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<MethodResult<bool>> Registration(UserDTO user)
        {
            throw new Exception();
        }

        [Authorize]
        [HttpGet]
        public async Task Get()
        {
            var test = User.Identity.IsAuthenticated;
        }
    }
}
