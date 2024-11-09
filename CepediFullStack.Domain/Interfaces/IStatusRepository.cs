using CepediFullStack.Domain.Entities;

namespace CepediFullStack.Domain.Interfaces
{
    public interface IStatusRepository : IRepository<Status>
    {
        public Task<Status?> GetByName(string name);
    }
}