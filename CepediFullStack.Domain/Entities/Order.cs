using System.ComponentModel.DataAnnotations;
using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateOnly OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public Guid StatusId { get; set; }
        public virtual Status Status { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = [];
    }
}