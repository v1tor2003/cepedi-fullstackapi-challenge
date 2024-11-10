namespace CepediFullStack.Domain.Interfaces
{
    public interface IOrderProductRelationship
    {
        Task AddOrderProductAsync(Guid orderId, Guid productId);
        Task RemoveOrderProductAsync(Guid orderId, Guid productId); 
    }
}