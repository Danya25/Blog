using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Common;
using MyBlog.Domain.DTO;
using MyBlog.Services.User.GetRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetRoles")]
        public async Task<MethodResult<List<RoleDTO>>> GetRoles()
        {
            var userId = int.Parse(User.Claims.First(t => t.Type == "UserId").Value);
            var result = await _mediator.Send(new GetRolesQuery(userId));

            var rolesDto = _mapper.Map<List<RoleDTO>>(result);
            return rolesDto.ToSuccessMethodResult();
        }
    }
}
