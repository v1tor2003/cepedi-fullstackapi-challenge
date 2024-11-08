using CepediFullStack.Domain.Common;
using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CepediFullStack.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext context) =>
            Context = context;
            
        public void Create(T entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletedAt = DateTimeOffset.UtcNow;
            Context.Remove(entity);
        }

        public async Task<T?> GetById(Guid id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>?> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }
    }
}