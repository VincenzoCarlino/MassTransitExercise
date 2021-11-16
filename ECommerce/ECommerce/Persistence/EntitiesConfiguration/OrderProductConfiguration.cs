using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.EntitiesConfiguration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("orders_products");

            builder.HasKey(e => new {e.OrderId, e.ProductId});
            builder.Property(e => e.OrderId)
                .HasColumnName("order_id");
            builder.Property(e => e.ProductId)
                .HasColumnName("product_id");
            builder.Property(e => e.ProductQuantity)
                .HasColumnName("product_quantity")
                .IsRequired();

            builder.HasOne(e => e.Order!)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product!)
                .WithMany(e => e.OrdersProduct)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}