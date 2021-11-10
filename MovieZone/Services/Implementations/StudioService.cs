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
    public class StudioService : IStudioService
    {
        IRepository<Studio> _repository;
        IMapper _mapper;

        public StudioService(IRepository<Studio> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<StudioDto>> GetStudios()
        {
            var studios = await _repository.GetAll();
            if(!studios.Any())
            {
                throw new NotFoundException("Not found any studios!");
            }
            return _mapper.Map<IEnumerable<StudioDto>>(studios);
        }
    }
}
