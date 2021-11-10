using Microsoft.AspNetCore.Mvc;
using MovieZone.API.Dtos.ActorsDtos;
using MovieZone.API.Exeptions;
using MovieZone.API.Models;
using MovieZone.API.Models.PagedRequest;
using MovieZone.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Controllers
{
    [Route("api/actors")]
    public class ActorsController : AppBaseController
    {

        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddActor([FromBody] CreateOrUpdateActorDto actorToUpdateOrCreate)
        {
            var actor = await _actorsService.AddActor(actorToUpdateOrCreate);
            return CreatedAtAction(nameof(GetActorById), new { id = actor.Id }, actor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, CreateOrUpdateActorDto actorDto)
        {
            await _actorsService.UpdateActor(id, actorDto);

            return Ok(actorDto);

        }

        [HttpGet("{id}")]
        public async Task<ActorDto> GetActorById(int id)
        {
            var actor = await _actorsService.GetActorById(id);

            return actor;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _actorsService.DeleteActor(id);

            return NoContent();

        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<ActorDto>> GetPagedActors(PagedRequest pagedRequest)
        {
            var actors = await _actorsService.GetPagedActors(pagedRequest);
            return actors;
        }

        [HttpPost("assignActor")]
        public async Task<IActionResult> AssignActorToMovie([FromBody] AssignActorRequest assignActorRequest)
        {
            var assigned = await _actorsService.AssignActorToMovie(assignActorRequest);

            return assigned ? Ok() : BadRequest();
        }
    }
}
