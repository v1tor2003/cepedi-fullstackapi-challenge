using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateAsync(T entity, T updatedEntity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>?> GetAllAsync();
        Task SaveAsync();
    }
}