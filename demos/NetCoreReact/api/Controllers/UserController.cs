using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using LoginAPI.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using LoginAPI.Services;
using LoginAPI.Dtos;
using LoginAPI.Models;
using LoginAPI.Utils;
using System.Linq;

namespace LoginAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized();


            TokenHelper.createToken(Response, user.UserId, user.RoleId, _appSettings.SecretKey, _appSettings.SessionExpiration);

            UserDto responseUserDTO = new UserDto()
            {
                UserId = user.UserId,
                Username = user.Username,
                RoleId = user.RoleId
            };
            return Ok(responseUserDTO);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            try
            {
                User userFromDB = _userService.Create(user, userDto.Password);
                if (userFromDB == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                userFromDB.Password = null;
                return Ok(_mapper.Map<UserDto>(userFromDB));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}