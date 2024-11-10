using System.Linq.Expressions;
using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CepediFullStack.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {}
    }
}