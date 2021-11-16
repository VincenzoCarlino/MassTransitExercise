using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(e => e.Description)
                .HasColumnName("description");
            builder.Property(e => e.AvailableQuantity)
                .HasColumnName("available_quantity")
                .IsRequired();
            builder.Property(e => e.Price)
                .HasColumnName("price")
                .IsRequired();
        }
    }
}