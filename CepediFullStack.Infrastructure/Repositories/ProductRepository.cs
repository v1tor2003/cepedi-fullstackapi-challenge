using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Context;

namespace CepediFullStack.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {}
    }
}