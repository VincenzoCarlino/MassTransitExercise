using ECommerce.Models;
using ECommerce.Persistence.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        internal static string DbConnectionString =
            "Host=localhost;Port=5432;Username=user;Password=password;Database=ecommerce;";

        internal DbSet<Product> Products { get; private set; } = null!;
        internal DbSet<Order> Orders { get; private set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
        }
    }
}