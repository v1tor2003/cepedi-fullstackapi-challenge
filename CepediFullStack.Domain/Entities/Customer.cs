using System.ComponentModel.DataAnnotations;
using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}