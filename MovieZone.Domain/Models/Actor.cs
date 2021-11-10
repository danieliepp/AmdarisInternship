using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Image { get; set; }

        public ActorBiography ActorBiography { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();
    }
}
