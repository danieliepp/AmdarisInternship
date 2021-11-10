using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MovieZone.API.Models.PagedRequest;
using MovieZone.Domain;
using MovieZone.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Repositories.Interfaces

{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _mapper = mapper;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            var addedEntity = _dbContext.Set<T>().FirstOrDefault(x => x.Id == entity.Id);

            return addedEntity;
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = IncludeProperties(includes);

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var query = _dbSet;
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<T> GetByIdWithInclude(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = IncludeProperties(includes);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity where TDto : class
        {
            return await _dbContext.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        }

        public async Task<IEnumerable<T>> GetWithInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = IncludeProperties(includes);
            return await query.ToListAsync();
        }

        public async Task<bool> Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<T> Update(T entity)
        {
            // In case AsNoTracking is used
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        private IQueryable<T> IncludeProperties(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> entities = _dbContext.Set<T>();
            if (includes != null)
                entities = includes(entities);

            return entities;
        }
    }
}