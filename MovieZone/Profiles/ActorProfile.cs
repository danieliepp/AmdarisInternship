using AutoMapper;
using MovieZone.API.Dtos.ActorsDtos;
using MovieZone.Domain;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {

            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();

            CreateMap<CreateOrUpdateActorDto, Actor>();
            CreateMap<Actor, CreateOrUpdateActorDto>();

            CreateMap<CreateUpdateActorBiographyDto, ActorBiography>();
            CreateMap<ActorBiography, CreateUpdateActorBiographyDto>();


            CreateMap<ActorBiography, ActorBiographyDto>();
            CreateMap<ActorBiographyDto, ActorBiography>();

            CreateMap<ActorMovie, ActorDto>()
                .ForMember(x => x.ActorBiography, y => y.MapFrom(z => z.Actor.ActorBiography))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.Actor.FirstName))
                .ForMember(x => x.SecondName, y => y.MapFrom(z => z.Actor.SecondName))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Actor.Id))
                .ForMember(x => x.Image, y => y.MapFrom(z => z.Actor.Image));

        }
    }
}
