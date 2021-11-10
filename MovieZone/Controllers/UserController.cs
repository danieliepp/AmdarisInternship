using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos.AccountDtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Exeptions;
using MovieZone.API.Services.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/")]
    public class UserController : AppBaseController
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            
            var response = await _userService.Register(registerUserDto);
            if(response != null)
            {
                return Ok(response);
            }

            return BadRequest(new RegistrationResponseDto()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {

            var response = await _userService.Login(loginUserDto);
            if (response != null)
            {
                return Ok(response);
            }

            return BadRequest(new LoginResponseDto()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });

        }
    }
}

