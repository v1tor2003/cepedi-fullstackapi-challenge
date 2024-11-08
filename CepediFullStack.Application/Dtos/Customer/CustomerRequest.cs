using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Customer
{
    public sealed record CustomerRequest(
        string Name, 
        string Email, 
        string PhoneNumber, 
        DateOnly BirthDate
    ) : BaseDto;
}