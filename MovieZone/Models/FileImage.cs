using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Models
{
    public class FileImage
    {
        public int Id { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
