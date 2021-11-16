using ECommerce.Store.Models;
using ECommerce.Store.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Store.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        internal static string DbConnectionString =
            "Host=localhost;Port=5432;Username=user;Password=password;Database=store;";

        internal DbSet<ProductQuantity> ProductQuantities { get; private set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductQuantityConfiguration());
        }
    }
}