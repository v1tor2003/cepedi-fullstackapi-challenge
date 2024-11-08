using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Context;

namespace CepediFullStack.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {}
    }
}