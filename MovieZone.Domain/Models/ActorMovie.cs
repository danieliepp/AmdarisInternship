﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain
{
    public class ActorMovie
    {
        public string Name { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }


        public Movie Movie { get; set; }
        public Actor Actor { get; set; }

    
    }

}
