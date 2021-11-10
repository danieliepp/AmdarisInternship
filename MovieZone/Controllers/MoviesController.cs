using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos.MoviesDtos;
using MovieZone.API.Models.PagedRequest;
using MovieZone.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/movies")]
    public class MoviesController : AppBaseController
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }


        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] CreateOrUpdateMovieDto movieDto)
        {
            var movie = await _moviesService.AddMovie(movieDto);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _moviesService.DeleteMovie(id);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, CreateOrUpdateMovieDto movieDto)
        {
            var updated = await _moviesService.UpdateMovie(id, movieDto);
            if (!updated)
            {
                return BadRequest("Movie you trying to Update doesn't exist");
            }

            return Ok(movieDto);

        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<MovieDto>> GetPagedMovies(PagedRequest pagedRequest)
        {
            var movies = await _moviesService.GetPagedMovies(pagedRequest);

            return movies;

        }

        [HttpGet("all")]
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var movies = await _moviesService.GetAll();

            return movies;
        }

        [HttpGet("{id}")]
        public async Task<MovieDto> GetMovieById(int id)
        {
            var movie = await _moviesService.GetMovieById(id);
            
            return movie;
        }

        [HttpGet("category")]
        public async Task<IEnumerable<MovieDto>> GetMoviesByCategory([FromQuery] int id)
        {
            var movies = await _moviesService.GetMoviesByCategory(id);

            return movies;
        }

    }
}
