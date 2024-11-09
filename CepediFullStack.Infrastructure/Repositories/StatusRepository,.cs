using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CepediFullStack.Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(AppDbContext context) : base(context)
        {}

        public async Task<Status?> GetByName(string name)
        {
            return await _context.Statuses.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}