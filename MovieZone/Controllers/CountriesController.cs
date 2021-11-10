using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/countries")]
    public class CountriesController : AppBaseController
    {
        private ICountriesService _repository;
        private IMapper _mapper;

        public CountriesController(ICountriesService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            var countries = _mapper.Map<IEnumerable<CountryDto>>(await _repository.GetCountries());

            return countries;
        }
    }
}
