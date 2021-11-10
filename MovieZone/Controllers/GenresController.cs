using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos.GenresDtos;
using MovieZone.API.Exeptions;
using MovieZone.API.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/genres")]
    public class GenresController : AppBaseController
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            var genres = await _genresService.GetGenres();

            return genres;
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] CreateOrUpdateGenreDto genreToAddOrUpdateDto)
        {
            var genre = await _genresService.AddGenre(genreToAddOrUpdateDto);

            return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _genresService.DeleteGenre(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, CreateOrUpdateGenreDto genreToUpdate)
        {
            await _genresService.UpdateGenre(id, genreToUpdate);
            return Ok(genreToUpdate);
        }

        [HttpGet("{id}")]
        public async Task<GenreDto> GetGenreById(int id)
        {
            var genre = await _genresService.GetGenreById(id);
            return genre;
        }
    }
}
