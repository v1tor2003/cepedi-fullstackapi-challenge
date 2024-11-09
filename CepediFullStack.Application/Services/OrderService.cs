using AutoMapper;
using CepediFullStack.Application.Dtos.Order;
using CepediFullStack.Domain.Common;
using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;

namespace CepediFullStack.Application.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IRepository<Order> repository, IMapper mapper) 
            : base(repository, mapper) {}
    }
}