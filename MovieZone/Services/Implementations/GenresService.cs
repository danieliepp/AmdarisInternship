using AutoMapper;
using MovieZone.API.Dtos.GenresDtos;
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
    public class GenresService : IGenresService
    {
        private readonly IRepository<Genre> _repository;
        private readonly IMapper _mapper;
        public GenresService(IRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenreDto> AddGenre(CreateOrUpdateGenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            var genreWithSameName = await _repository.FindBy(x => x.Name == genreDto.Name);
            if (genreWithSameName.Any())
            {
                //TODO Please do validation in beginning of the method.
                throw new EntryAlreadyExistsException($"Genre with name '{genreDto.Name} already exist!");
            }

            var addedGenre = await _repository.Add(genre);
            return _mapper.Map<GenreDto>(addedGenre);
        }

        public async Task<bool> DeleteGenre(int id)
        {

            var genreToDelete = await _repository.FirstOrDefault(x => x.Id == id);
            if (genreToDelete == null)
            {
                throw new NotFoundException($"Genre you trying to delete doesn't exist!");
            }
            var deleted = await _repository.Remove(genreToDelete);
            return deleted;
        }

        public async Task<GenreDto> GetGenreById(int id)
        {
            var genre = _mapper.Map<GenreDto>(await _repository.GetById(id));
            if (genre == null)
            {
                throw new NotFoundException($"Genre with {id} doesn't exist");
            }
            return genre;
        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            return _mapper.Map<IEnumerable<GenreDto>>(await _repository.GetAll());
        }

        public async Task<bool> UpdateGenre(int id, CreateOrUpdateGenreDto genreDto)
        {
            var genre = await _repository.GetById(id);
            if (genre == null)
            {
                throw new NotFoundException($"Genre you trying to Update doesn't exist");
            }

            genre.Name = genreDto.Name;
            var updated = await _repository.SaveAll();
            return updated;
        }
    }
}
