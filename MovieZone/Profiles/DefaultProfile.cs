using AutoMapper;
using MovieZone.API.Dtos;
using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Profiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<Studio, StudioDto>();
            CreateMap<StudioDto, Studio>();

            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();
        }
    }
}
