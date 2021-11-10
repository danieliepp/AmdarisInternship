using MovieZone.API.Dtos.GenresDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Interfaces
{
    public interface IGenresService
    {
        Task<IEnumerable<GenreDto>> GetGenres();
        Task<bool> UpdateGenre(int id, CreateOrUpdateGenreDto genre);
        Task<bool> DeleteGenre(int id);
        Task<GenreDto> AddGenre(CreateOrUpdateGenreDto genre);

        Task<GenreDto> GetGenreById(int id);

    }
}
