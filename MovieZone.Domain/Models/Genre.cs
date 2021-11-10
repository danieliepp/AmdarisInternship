using MovieZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<GenreMovie> GenresMovies { get; set; } = new List<GenreMovie>();
    }
}
