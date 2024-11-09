using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Order
{
    public sealed record OrderResponse : BaseDto
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly UpdatedAt { get; set; }
    }
}