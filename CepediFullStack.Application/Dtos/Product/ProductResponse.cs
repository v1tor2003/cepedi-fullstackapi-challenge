using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos
{
    public sealed record ProductResponse : BaseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}