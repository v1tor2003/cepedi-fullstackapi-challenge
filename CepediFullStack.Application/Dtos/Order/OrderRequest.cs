using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Order
{
    public sealed record OrderRequest(
        Guid StatusId,
        Guid CustomerId, 
        DateOnly OrderDate
    ) : BaseDto;
}