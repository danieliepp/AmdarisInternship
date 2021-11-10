using MovieZone.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Dtos.ActorsDtos
{
    public class CreateOrUpdateActorDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Image { get; set; }
        public CreateUpdateActorBiographyDto ActorBiography { get; set; }
    }
}
