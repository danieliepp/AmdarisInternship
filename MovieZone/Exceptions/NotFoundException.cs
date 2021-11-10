using MovieZone.API.Exeptions;
using Newtonsoft.Json;
using System.Net;

namespace MovieZone.API.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(HttpStatusCode.BadRequest, message) {}
    }
}
