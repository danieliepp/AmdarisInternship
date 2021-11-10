using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieZone.API.Dtos.ActorsDtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Models;
using MovieZone.API.Models.PagedRequest;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Implementations
{
    public class ActorsService : IActorsService
    {
        private readonly IRepository<Actor> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Movie> _movieRepository;

        public ActorsService(IRepository<Actor> repository, IMapper mapper, IRepository<Movie> movieRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<ActorDto> AddActor(CreateOrUpdateActorDto actorToUpdateOrCreate)
        {
            var actor = _mapper.Map<Actor>(actorToUpdateOrCreate);
            var actorsWithSameName = await _repository.FindBy(x => x.FirstName == actor.FirstName && x.SecondName == actor.SecondName);
            if(actorsWithSameName.Any())
            {
                throw new EntryAlreadyExistsException($"Actor: '{actor.FirstName} {actor.SecondName}' already exist!");
            }

            actor.ActorBiography = _mapper.Map<ActorBiography>(actorToUpdateOrCreate.ActorBiography);

            var addedActor = await _repository.Add(actor);
            return _mapper.Map<ActorDto>(addedActor);
        }

        public async Task<bool> AssignActorToMovie(AssignActorRequest assignActorRequest)
        {
            var movie = await _movieRepository.FirstOrDefault(x => x.Id == assignActorRequest.MovieId);
            if(movie == null)
            {
                throw new NotFoundException("Movie you trying to assign an actor doesn't exist");
            }
            var actor = await _repository.FirstOrDefault(x => x.Id == assignActorRequest.ActorId);
            if (actor == null)
            {
                throw new NotFoundException("Actor you trying to assign to the movie doesn't exist");
            }

            var actorRole = new ActorMovie
            {
                Actor = _mapper.Map<Actor>(actor),
                Movie = _mapper.Map<Movie>(movie),
                ActorId = assignActorRequest.ActorId,
                MovieId = assignActorRequest.MovieId,
                Name = assignActorRequest.RoleName
            };
            actor.ActorMovies.Add(actorRole);
            await _repository.Update(actor);

            return await _repository.SaveAll();
        }

        public async Task<bool> DeleteActor(int id)
        {
            var actorToDelete = await _repository.FirstOrDefault(x => x.Id == id);
            if (actorToDelete == null)
            {
                throw new NotFoundException($"Actor you trying to delete doesn't exist!");
            }
            var deleted = await _repository.Remove(actorToDelete);

            return deleted;
        }

        public async Task<ActorDto> GetActorById(int id)
        {
            var actor = await _repository.GetByIdWithInclude(id, includes: x=>x.Include(x=>x.ActorMovies));
            if(actor == null)
            {
                throw new NotFoundException("Actor you trying to get doesn't exist!");
            }
            return _mapper.Map<ActorDto>(actor);
        }


        public async Task<PaginatedResult<ActorDto>> GetPagedActors(PagedRequest pagedRequest)
        {
            var pagedActorData = await _repository.GetPagedData<Actor, ActorDto>(pagedRequest);
            return pagedActorData;
        }

        public async Task<bool> UpdateActor(int id, CreateOrUpdateActorDto actorToUpdateOrCreate)
        {
            var actor = await _repository.GetByIdWithInclude(id, x => x.Include(x => x.ActorBiography));

            if (actor == null)
            {
                throw new NotFoundException($"Actor you trying to Update doesn't exist");
            }
            _mapper.Map(actorToUpdateOrCreate, actor);

            var saved = await _repository.SaveAll();

            return saved;
        }
    }
}
