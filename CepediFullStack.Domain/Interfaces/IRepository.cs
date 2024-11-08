using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>?> GetAll();
    }
}