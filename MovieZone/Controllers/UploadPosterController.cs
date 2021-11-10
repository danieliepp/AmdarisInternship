using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos.MoviesDtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Exeptions;
using MovieZone.API.Models;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/[controller]")]
    public class UploadPosterController : AppBaseController
    {
        private readonly IStorageService _storageService;
        private readonly IMoviesService _movieService;
        private readonly IMapper _mapper;

        public UploadPosterController(IStorageService storageService, IMoviesService movieService, IMapper mapper)
        {
            _storageService = storageService;
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_storageService.GetPoster(id));
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileImage file)
        {
            var posterUrl = _storageService.Upload(file);
            var movie = await _movieService.GetMovieById(file.Id);
            if (movie == null)
            {
                throw new NotFoundException("Movie you want to assign poster doesn't exist!");
            }
            movie.Poster = posterUrl;
            var updated = await _movieService.UpdateMovie(movie.Id, _mapper.Map<CreateOrUpdateMovieDto>(movie));
            return updated ? Content(posterUrl) : BadRequest();
        }
    }
}
