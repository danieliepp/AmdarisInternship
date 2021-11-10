using MovieZone.API.Dtos.AccountDtos;
using MovieZone.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Interfaces.Auth
{
    public interface IUserService
    {
        public Task<RegistrationResponseDto> Register(RegisterUserDto registerUserDto);
        public Task<LoginResponseDto> Login(LoginUserDto loginUserDto);
    }
}
