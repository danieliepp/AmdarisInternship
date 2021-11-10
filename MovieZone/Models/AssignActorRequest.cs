using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Models
{
    public class AssignActorRequest
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string RoleName { get; set; }
    }
}
