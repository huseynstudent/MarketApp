using MarketApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApp.EntityConfiguration;
public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);

        builder.HasMany(s => s.Products)
               .WithOne(p => p.Supplier)
               .HasForeignKey(p => p.SupplierId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
