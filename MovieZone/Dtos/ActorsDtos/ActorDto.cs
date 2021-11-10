using MovieZone.API.Dtos.ActorsDtos;
using MovieZone.API.Dtos.MoviesDtos;
using System.Collections.Generic;

namespace MovieZone.API.Dtos.ActorsDtos
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Image { get; set; }
        public ActorBiographyDto ActorBiography { get; set; }
    }
}
