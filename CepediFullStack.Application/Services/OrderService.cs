using AutoMapper;
using CepediFullStack.Domain.Common;
using CepediFullStack.Domain.Entities;
using CepediFullStack.Domain.Interfaces;

namespace CepediFullStack.Application.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(
            IRepository<Order> repository, IMapper mapper) 
            : base(repository, mapper) {}
        public async Task AddOrderProductAsync(Guid orderId, Guid productId)
        {
            var order = await _repository.GetByIdAsync(
                orderId, 
                o => o.OrderProducts
            ) ?? throw new ArgumentException("Order not found.");

            if (order.OrderProducts.Any(op => op.ProductId == productId))
                throw new InvalidOperationException("Product is already associated with this order.");
            
            int amount = order.OrderProducts.Count(op => op.OrderId == orderId) + 1;

            var orderProduct = new OrderProduct
            {
                OrderId = orderId,
                ProductId = productId,
                ProductAmount = amount
            };

            order.OrderProducts.Add(orderProduct);

            await _repository.UpdateAsync(order);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<TDto>?> GetProductsAsync<TDto>(Guid orderId)
            where TDto : BaseDto
        {
            var order = await _repository.GetByIdAsync(
                orderId,
                o => o.OrderProducts
            );

            if(order is null) return [];

            return order.OrderProducts.Select(op => _mapper.Map<TDto> (op.Product)).ToList();
        }

        public async Task RemoveOrderProductAsync(Guid orderId, Guid productId)
        {
            var order = await _repository.GetByIdAsync(
                orderId,
                o => o.OrderProducts
            ) ?? throw new ArgumentException("Order not found");

            var existingOrderProduct = order.OrderProducts.FirstOrDefault(op => op.ProductId == productId) 
             ?? throw new InvalidOperationException("Product is not associated with this order.");

            order.OrderProducts.Remove(existingOrderProduct);

            await _repository.UpdateAsync(order);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<TDto>?> GetAllWithIncludesAsync<TDto>() where TDto : BaseDto
        {
            var orders = await _repository.GetAllAsync(
                o => o.Status,
                o => o.Customer
            );

            if(orders is null || !orders.Any()) return [];

            return orders.Select(_mapper.Map<TDto>).ToList();
        }

        public async Task<TDto?> GetByIdWithIncludesAsync<TDto>(Guid orderId) where TDto : BaseDto
        {
            var order = await _repository.GetByIdAsync(
                orderId,
                o => o.Status,
                o => o.Customer
            );

            if(order is null ) return null;

            return _mapper.Map<TDto>(order);
        }

        public async Task<TDto?> GetProductAsync<TDto>(Guid orderId, Guid productId) where TDto : BaseDto
        {
            var order = await _repository.GetByIdAsync(
                orderId,
                o => o.OrderProducts
            );

            if(order is null) return null;

            var product = order.OrderProducts.FirstOrDefault(op => op.ProductId == productId);
            return _mapper.Map<TDto>(product);
        }
    }
}