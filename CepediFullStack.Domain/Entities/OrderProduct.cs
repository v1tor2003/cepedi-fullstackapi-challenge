namespace CepediFullStack.Domain.Entities
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int ProductAmount { get; set; }
    }
}