using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common;
using MyBlog.Domain.Business;
using MyBlog.Domain.DTO;
using MyBlog.Services.Auth;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<MethodResult<UserInfoDTO>> Login(UserLoginDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var userInfo = await _authService.Login(userModel);
            var userInfoDto = _mapper.Map<UserInfoDTO>(userInfo);

            return userInfoDto.ToSuccessMethodResult();
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<MethodResult<bool>> Registration(UserRegistrationDTO user)
        {

            var userModel = _mapper.Map<UserModel>(user);
            var userInfo = await _authService.Registration(userModel);

            return userInfo.ToSuccessMethodResult();
        }
    }
}
