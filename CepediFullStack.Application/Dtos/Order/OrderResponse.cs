using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Order
{
    public sealed record OrderResponse : BaseDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public DateOnly OrderDate { get; set; }
    }
}