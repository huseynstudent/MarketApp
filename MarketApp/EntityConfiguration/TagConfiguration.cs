using MarketApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApp.EntityConfiguration;
public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Label).IsRequired().HasMaxLength(50);
        builder.HasMany(t => t.Products)
               .WithMany(p => p.Tags)
               .UsingEntity<Dictionary<string, object>>(
                   "ProductTag",
                   j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.Cascade),
                   j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.Cascade),
                   j =>
                   {
                       j.HasKey("ProductId", "TagId");
                       j.ToTable("ProductTags");
                   });
    }
}