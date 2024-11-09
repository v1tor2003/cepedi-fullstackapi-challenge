using AutoMapper;
using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;

namespace CepediFullStack.Application.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {}
    }
}