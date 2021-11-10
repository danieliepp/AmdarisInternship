using MovieZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieZone.Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int StudioId { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public float Rating { get; set; }
        public string Poster { get; set; }
        public string VideoUrl { get; set; }

        public Studio Studio { get; set; }
        public Country Country { get; set; }
        public Language Language { get; set; }
        public Category Category { get; set; }

        public ICollection<GenreMovie> GenresMovies { get; set; } = new List<GenreMovie>();

        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();
    }
}
