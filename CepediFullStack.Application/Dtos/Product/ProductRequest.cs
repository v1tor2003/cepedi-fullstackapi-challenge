using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Product
{
    public sealed record ProductRequest(
        string Name, 
        string Type, 
        decimal Price
    ) : BaseDto;
}