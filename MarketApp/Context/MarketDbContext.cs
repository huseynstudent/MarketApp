using MarketApp.Entities;
using MarketApp.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.Context;

class MarketDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=STHQ0128-08;Initial Catalog=AcademyMarket;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}
