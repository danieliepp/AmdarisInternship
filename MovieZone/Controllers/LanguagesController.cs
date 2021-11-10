using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Exeptions;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/languages")]
    public class LanguagesController : AppBaseController
    {
        private ILanguageService _repository;
        private IMapper _mapper;

        public LanguagesController(ILanguageService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LanguageDto>> GetLanguages()
        {
            var languages = await _repository.GetLanguages();
            var result = _mapper.Map<IEnumerable<LanguageDto>>(languages);

            if(!result.Any())
            {
                throw new NotFoundException("Not found any languages!");
            }

            return result;
        }
    }
}
