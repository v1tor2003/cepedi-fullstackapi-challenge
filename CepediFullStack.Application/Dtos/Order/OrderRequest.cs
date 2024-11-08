namespace CepediFullStack.Application.Dtos.Order
{
    public sealed record OrderRequest(
        string StatusName, 
        DateOnly OrderDate
    );
}