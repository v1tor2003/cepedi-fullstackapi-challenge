//using CepediFullStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CepediFullStack.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
    }
}