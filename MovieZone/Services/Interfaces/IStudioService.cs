using MovieZone.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Interfaces
{
    public interface IStudioService
    {
        Task<IEnumerable<StudioDto>> GetStudios();
    }
}
