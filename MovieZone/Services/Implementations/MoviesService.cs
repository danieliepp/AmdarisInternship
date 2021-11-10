using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieZone.API.Dtos.MoviesDtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Models.PagedRequest;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Domain.Models;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Implementations
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;
        public MoviesService(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MovieDto> AddMovie(CreateOrUpdateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);

            var moviesWithSameTitle = await _repository.FindBy(m => m.Title == movieDto.Title);

            if (moviesWithSameTitle.Any())
            {
                //TODO Please do validation in beginning of the method. 
                throw new EntryAlreadyExistsException($"Movie with title '{movieDto.Title}' already exist!");
            }
            foreach (var genreId in movieDto.GenresIds)
            {
                movie.GenresMovies.Add(new GenreMovie { GenreId = genreId, MovieId = movie.Id });
            }

            var addedMovie = await _repository.Add(movie);
            return _mapper.Map<MovieDto>(addedMovie);
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movieToDelete = await _repository.FirstOrDefault(x => x.Id == id);
            if (movieToDelete == null)
            {
                throw new NotFoundException($"Movie with id {id} doesn't exist!");
            }
            var deleted = await _repository.Remove(movieToDelete);

            return deleted;
        }

        public async Task<MovieDto> GetMovieById(int id)
        {
            var movie = await _repository.GetByIdWithInclude(id, includes: x => x.Include(x=> x.GenresMovies).ThenInclude(x => x.Genre).Include(x=>x.Category).Include(x => x.Language).Include(x => x.Studio).Include(x => x.ActorMovies).ThenInclude(x=>x.Actor));
            var result = _mapper.Map<MovieDto>(movie);
            if (result == null)
            {
                throw new NotFoundException($"Movie with id '{id} doesn't exist!");
            }
            return result;
        }

        public async Task<PaginatedResult<MovieDto>> GetPagedMovies(PagedRequest pagedRequest)
        {
            var pagedMoviesDto = await _repository.GetPagedData<Movie, MovieDto>(pagedRequest);
            return pagedMoviesDto;
        }

        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var movies = await _repository.GetWithInclude();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByCategory(int id)
        {
            var moviesByCategory = await _repository.FindBy(x => x.CategoryId == id);
            var result = _mapper.Map<IEnumerable<MovieDto>>(moviesByCategory);
            
            return result;
        }

        public async Task<bool> UpdateMovie(int id, CreateOrUpdateMovieDto movieDto)
        {
            var movie = await _repository.GetById(id);

            if (movie == null)
            {
                throw new NotFoundException($"Movie you trying to Update doesn't exist");
            }
            _mapper.Map(movieDto, movie);

            var saved = await _repository.SaveAll();

            return saved;

        }

    }
}
