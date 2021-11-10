using AutoMapper;
using MovieZone.API.Dtos.GenresDtos;
using MovieZone.API.Dtos.MoviesDtos;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Domain.Models;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {

            CreateMap<Movie, MovieDto>()
                .ForMember(x => x.Country, y => y.MapFrom(z => z.Country.Name))
                .ForMember(x => x.Language, y => y.MapFrom(z => z.Language.Name))
                .ForMember(x => x.Studio, y => y.MapFrom(z => z.Studio.Name))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Name))
                .ForMember(x => x.Actors, y => y.MapFrom(z => z.ActorMovies))
                .ForMember(x => x.Genres, y => y.MapFrom(z => z.GenresMovies));

            CreateMap<MovieDto, Movie>();

            CreateMap<CreateOrUpdateMovieDto, Movie>();
            CreateMap<Movie, CreateOrUpdateMovieDto>();

            CreateMap<CreateOrUpdateMovieDto, MovieDto>();
            CreateMap<MovieDto, CreateOrUpdateMovieDto>();



        }
    }
}
