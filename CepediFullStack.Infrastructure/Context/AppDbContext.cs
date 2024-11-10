using CepediFullStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CepediFullStack.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCustomerOrderRelationship();
            modelBuilder.ConfigureOrderStatusesRelationship();
            modelBuilder.ConfigureOrderProductRelationship();
            modelBuilder.SeedStatuses();
            base.OnModelCreating(modelBuilder);
        }
    }
}