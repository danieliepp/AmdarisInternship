using AutoMapper;
using MovieZone.API.Dtos.AccountDtos;
using MovieZone.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, RegisterUserDto>();
            CreateMap<RegisterUserDto, User>();

            CreateMap<RegisterUserDto, UserDto >();

            CreateMap<LoginUserDto, UserDto>();

            CreateMap<User, LoginUserDto>();

        }
    }
}
