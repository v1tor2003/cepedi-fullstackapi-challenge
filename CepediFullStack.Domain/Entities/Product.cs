using System.ComponentModel.DataAnnotations;
using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = [];
    }
}