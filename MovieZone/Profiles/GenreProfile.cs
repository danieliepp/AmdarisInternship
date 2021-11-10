using AutoMapper;
using MovieZone.API.Dtos.GenresDtos;
using MovieZone.API.Dtos.MoviesDtos;
using MovieZone.Domain;
using MovieZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<Genre, CreateOrUpdateGenreDto>();
            CreateMap<CreateOrUpdateGenreDto, Genre>();

            CreateMap<GenreMovie, GenreDto>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Genre.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Genre.Name));
        }
    }
}
