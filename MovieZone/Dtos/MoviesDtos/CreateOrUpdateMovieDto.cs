using MovieZone.API.Dtos.GenresDtos;
using MovieZone.API.Models;
using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Dtos.MoviesDtos
{
    public class CreateOrUpdateMovieDto
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? StudioId { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? CountryId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? LanguageId { get; set; }
        [Required]
        public int[] GenresIds { get; set; }

        [Required]
        [Range(30, 200)]
        public int? Duration { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? CategoryId { get; set; }

        [Required]
        [Range(1, 10)]
        public float Rating { get; set; }
        public string Poster { get; set; }
        /*        public IEnumerable<MediaArtDto> MediaArtDtos { get; set; }*/
        [DataType(DataType.Url)]
        public string VideoUrl { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; set; }

    }
}
