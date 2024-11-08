using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}