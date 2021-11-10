using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieZone.API.Dtos.AccountDtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Services.Interfaces.Auth;
using MovieZone.Domain.Models;
using MovieZone.Domain.Models.Auth;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MovieZone.API.Services.Implementations.Auth
{
    public class UserService : IUserService
    {

        private readonly UserManager<User> _userManager;
        private readonly AppSettings _appSettings;

        public UserService(UserManager<User> userManager, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _userManager = userManager;
            _appSettings = optionsMonitor.CurrentValue;
        }
        public async Task<LoginResponseDto> Login(LoginUserDto loginUserDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(loginUserDto.Email);

            if(existingUser == null)
            {
                throw new AuthException(new LoginResponseDto()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Invalid authentication request"
                    }
                });
            }

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, loginUserDto.Password);

            if(isCorrect)
            {
                var jwtToken = GenerateJwtToken(existingUser);

                return new LoginResponseDto()
                {
                    Result = true,
                    Token = jwtToken
                };
            }else
            {
                throw new AuthException(new LoginResponseDto()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Invalid authentication request"
                    }
                });
            }
        }

        public async Task<RegistrationResponseDto> Register(RegisterUserDto registerUserDto)
        {
            var existingUser = await _userManager.FindByNameAsync(registerUserDto.Email);
            if(existingUser != null)
            {
                throw new AuthException(new RegistrationResponseDto()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Email already exist"
                    }
                });
            }

            var newUser = new User()
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.Username
            };
            var isCreated = await _userManager.CreateAsync(newUser, registerUserDto.Password);

            if(isCreated.Succeeded)
            {
                var jwtToken = GenerateJwtToken(newUser);

                return new RegistrationResponseDto()
                {
                    Result = true,
                    Token = jwtToken
                };
            }
            else
            {
                throw new AuthException(new RegistrationResponseDto()
                {
                    Result = false,
                    Errors = isCreated.Errors.Select(x => x.Description).ToList()
                });
            }
        }

        private string GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
