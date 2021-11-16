using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.EntitiesConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.User)
                .HasColumnName("user").IsRequired();
            builder.Property(e => e.Address)
                .HasColumnName("address").IsRequired();
            builder.Property(e => e.Status)
                .HasColumnName("status").IsRequired();
            builder.Property(e => e.TotalPrice)
                .HasColumnName("total_price").IsRequired();
        }
    }
}