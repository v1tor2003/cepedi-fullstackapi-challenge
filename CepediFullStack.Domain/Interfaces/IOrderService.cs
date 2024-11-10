using CepediFullStack.Domain.Common;
using CepediFullStack.Domain.Entities;

namespace CepediFullStack.Domain.Interfaces
{
    public interface IOrderService : IService<Order>, IOrderProductRelationship
    {
        Task<TDto?> GetProductAsync<TDto>(Guid orderId, Guid productId) where TDto : BaseDto;
        Task<IEnumerable<TDto>?> GetProductsAsync<TDto>(Guid orderId) where TDto : BaseDto;
        Task<IEnumerable<TDto>?> GetAllWithIncludesAsync<TDto>() where TDto : BaseDto;
        Task<TDto?> GetByIdWithIncludesAsync<TDto>(Guid orderId) where TDto : BaseDto;
    }
}