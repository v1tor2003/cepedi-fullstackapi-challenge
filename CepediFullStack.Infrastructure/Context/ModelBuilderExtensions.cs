using CepediFullStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void ConfigureCustomerOrderRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
                    .HasMany(c => c.Orders)
                    .WithOne(o => o.Customer)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
    }

    public static void ConfigureOrderStatusesRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
                    .HasOne(o => o.Status)
                    .WithMany(s => s.Orders)
                    .HasForeignKey(o => o.StatusId)
                    .OnDelete(DeleteBehavior.Restrict);
    }

    public static void ConfigureOrderProductRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
                    .HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder.Entity<OrderProduct>()
                    .HasOne(op => op.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
                    .HasOne(op => op.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(op => op.ProductId);
    }

    public static void SeedStatuses(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>()
                    .HasData(
                        new Status { Id = Guid.NewGuid(), Name = "Pendente", CreatedAt = DateTimeOffset.UtcNow},
                        new Status { Id = Guid.NewGuid(), Name = "Aprovado", CreatedAt = DateTimeOffset.UtcNow},
                        new Status { Id = Guid.NewGuid(), Name = "Entregue", CreatedAt = DateTimeOffset.UtcNow}
                    );
    }
}