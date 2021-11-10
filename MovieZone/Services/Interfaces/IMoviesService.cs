using MovieZone.API.Dtos.MoviesDtos;
using MovieZone.API.Models.PagedRequest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<MovieDto> GetMovieById(int id);

        Task<PaginatedResult<MovieDto>> GetPagedMovies(PagedRequest pagedRequest);
        Task<IEnumerable<MovieDto>> GetAll();

        Task<bool> UpdateMovie(int id, CreateOrUpdateMovieDto movie);
        Task<bool> DeleteMovie(int id);
        Task<MovieDto> AddMovie(CreateOrUpdateMovieDto movie);
        Task<IEnumerable<MovieDto>> GetMoviesByCategory(int id);

    }
}
