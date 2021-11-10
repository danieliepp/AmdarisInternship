using MovieZone.API.Exeptions;
using MovieZone.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieZone.API.Exceptions
{
    public class AuthException : ApiException
    {
        public AuthException(AuthResult authResult) : base(HttpStatusCode.BadRequest, authResult.Errors.FirstOrDefault(), authResult)
        {
        }
    }
}
