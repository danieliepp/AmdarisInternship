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
    public class LanguageService : ILanguageService
    {
        IRepository<Language> _repository;
        IMapper _mapper;

        public LanguageService(IRepository<Language> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<LanguageDto>> GetLanguages()
        {
            var languages = await _repository.GetAll();
            if (!languages.Any())
            {
                throw new NotFoundException("Not found any language!");
            }
            return _mapper.Map<IEnumerable<LanguageDto>>(languages);
        }
    }
}
