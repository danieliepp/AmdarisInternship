using Microsoft.EntityFrameworkCore.Query;
using MovieZone.API.Models.PagedRequest;
using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<T> GetByIdWithInclude(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Remove(T entity);
        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity where TDto : class;
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        Task<bool> SaveAll();

        Task<IEnumerable<T>> GetWithInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
    }
}
