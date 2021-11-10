using MovieZone.API.Dtos.GenresDtos;
using System;
using System.Collections.Generic;
using MovieZone.API.Dtos.ActorsDtos;
using MovieZone.Domain;

namespace MovieZone.API.Dtos.MoviesDtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Studio { get; set; }
        public int StudioId { get; set; }

        public string Description { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }

        public string Language { get; set; }
        public int LanguageId { get; set; }

        public int Duration { get; set; }
        public float Rating { get; set; }
        public string Poster { get; set; }
        public string Category { get; set; }
        public string CategoryId { get; set; }

        /*        public IEnumerable<MediaArtDto> MediaArtDtos { get; set; }*/
        public string VideoUrl { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }

        public IEnumerable<ActorDto> Actors { get; set; }


    }
}
