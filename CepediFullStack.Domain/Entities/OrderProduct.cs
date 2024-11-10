namespace CepediFullStack.Domain.Entities
{
    public class OrderProduct 
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public int ProductAmount { get; set; }
    }
}