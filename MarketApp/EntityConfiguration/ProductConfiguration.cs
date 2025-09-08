using MarketApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApp.EntityConfiguration;

class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
        //   lazim deyil imis, çünki EF Core bunu avtomatik tanıyır
        //builder.HasMany(p => p.Orders)
        //       .WithMany(o => o.Products)
        //       .UsingEntity<Dictionary<string, object>>(
        //           "OrderProduct",
        //           j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.Cascade),
        //           j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.Cascade),
        //           j =>
        //           {
        //               j.HasKey("OrderId", "ProductId");
        //               j.ToTable("OrderProducts");
        //           });


    }
}
