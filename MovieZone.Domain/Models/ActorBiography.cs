using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain
{
    public class ActorBiography : BaseEntity
    {
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get { return (DateTime.Today - DateOfBirth).Days / 365; }
        }
        public Nullable<DateTime> DateOfDeath { get; set; }

        public string Gender { get; set; }
        public int ActorId { get; set; }

        public string Biography { get; set; }

        public Actor Actor { get; set; }
    }
}
