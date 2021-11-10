using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos;
using MovieZone.API.Exeptions;
using MovieZone.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/studio")]
    public class StudioController : AppBaseController
    {
        private readonly IStudioService _studioService;

        public StudioController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        [HttpGet]
        public async Task<IEnumerable<StudioDto>> GetStudios()
        {
            var studios = await _studioService.GetStudios();

            return studios;
        }

    }
}
