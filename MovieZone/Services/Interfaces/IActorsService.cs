
using MovieZone.API.Dtos.ActorsDtos;
using MovieZone.API.Models;
using MovieZone.API.Models.PagedRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Interfaces
{
    public interface IActorsService
    {
        Task<PaginatedResult<ActorDto>> GetPagedActors(PagedRequest pagedRequest);
        Task<bool> UpdateActor(int id, CreateOrUpdateActorDto genre);
        Task<bool> DeleteActor(int id);
        Task<ActorDto> AddActor(CreateOrUpdateActorDto genre);

        Task<ActorDto> GetActorById(int id);

        Task<bool> AssignActorToMovie(AssignActorRequest assignActorRequest);

    }
}
