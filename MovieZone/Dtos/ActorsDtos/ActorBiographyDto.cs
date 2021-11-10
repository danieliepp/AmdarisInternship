using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Dtos.ActorsDtos
{
    public class ActorBiographyDto
    {
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Nullable<DateTime> DateOfDeath { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }

    }
}
