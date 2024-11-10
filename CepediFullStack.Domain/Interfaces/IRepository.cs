using System.Linq.Expressions;
using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        abstract IQueryable<T>  BuildQueryWithIncludes(params Expression<Func<T, object>>[] includes);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateAsync(T entity, T updatedEntity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>?> GetAllAsync();
        Task<IEnumerable<T>?> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task SaveAsync();
    }
}