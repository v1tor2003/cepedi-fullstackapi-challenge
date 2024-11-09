using CepediFullStack.Domain.Common;

namespace CepediFullStack.Application.Dtos.Status
{
    public sealed record StatusResponse : BaseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}