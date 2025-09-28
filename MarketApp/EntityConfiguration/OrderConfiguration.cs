using MarketApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApp.EntityConfiguration
{  
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderNumber).IsRequired().HasMaxLength(15);

            builder.HasMany(o => o.Products)
                   .WithOne(p => p.Order)
                     .HasForeignKey(p => p.OrderId)
                        .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
