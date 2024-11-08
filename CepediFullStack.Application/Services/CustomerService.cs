using AutoMapper;
using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;

namespace CepediFullStack.Application.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository, IMapper mapper) : base(repository, mapper)
        {}
    }
}