﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain.Models
{
    public class GenreMovie
    {
        public int GenreId { get; set; }
        public int MovieId { get; set; }
        public Genre Genre { get; set; }
        public Movie Movie { get; set; }
    }
}
