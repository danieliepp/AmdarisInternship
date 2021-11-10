using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Dtos.ActorsDtos
{
    public class ActorMovieDto
    {
        public string Name { get; set; }
        public Movie Movie { get; set; }
    }
}
