using System.Linq.Expressions;
using CepediFullStack.Domain.Common;
using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CepediFullStack.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context) =>
            _context = context;
            
        public async Task CreateAsync(T entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            await _context.AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            _context.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity, T updatedEntity)
        {
            updatedEntity.CreatedAt = entity.CreatedAt;
            updatedEntity.UpdatedAt = DateTimeOffset.UtcNow;

            var baseEntityProps = typeof(BaseEntity).GetProperties()
                .Select(p => p.Name)
                .ToList();

            var entityEntry = _context.Entry(entity);
            foreach(var prop in entityEntry.OriginalValues.Properties)
            {
                if(!baseEntityProps.Contains(prop.Name))
                {
                    var newValue = updatedEntity.GetType().GetProperty(prop.Name)?.GetValue(updatedEntity);
                    if(newValue is not null)
                        entityEntry.Property(prop.Name).CurrentValue = newValue;
                }
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            entity.DeletedAt = DateTimeOffset.UtcNow;
            _context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>?> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            return await BuildQueryWithIncludes(includes).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            return await BuildQueryWithIncludes(includes).FirstOrDefaultAsync(entity => EF.Property<Guid>(entity, "Id") == id);
        }
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public IQueryable<T> BuildQueryWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            foreach(var include in includes) 
               query = query.Include(include);

            return query;
        }
    }
}