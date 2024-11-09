using CepediFullStack.Application.Dtos;
using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Customer
{
    public sealed record CustomerResponse : BaseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}