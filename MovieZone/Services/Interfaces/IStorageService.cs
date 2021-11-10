using Microsoft.AspNetCore.Http;
using MovieZone.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Interfaces
{
    public interface IStorageService
    {
        string Upload(FileImage file);
        string GetPoster(int id);
        void DeleteFile(string uniqueFileIdentifier);
    }
}
