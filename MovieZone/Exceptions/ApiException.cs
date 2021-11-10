using MovieZone.API.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MovieZone.API.Exeptions
{
    public class ApiException : Exception
    {

        public HttpStatusCode StatusCode { get; }

        public ApiException(HttpStatusCode statusCode, string message, AuthResult authResult = null) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
