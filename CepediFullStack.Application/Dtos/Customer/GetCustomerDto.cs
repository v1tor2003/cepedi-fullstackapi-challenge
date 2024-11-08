using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Customer
{
    public record GetCustomerDto : BaseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}