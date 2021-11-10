using AutoMapper;
using MovieZone.API.Dtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Implementations
{
    public class CountriesService : ICountriesService
    {
        IRepository<Country> _repository;
        IMapper _mapper;

        public CountriesService(IRepository<Country> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            var countries = await _repository.GetAll();
            if (!countries.Any())
            {
                throw new NotFoundException("Not found any countries!");
            }
            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }
    }
}
