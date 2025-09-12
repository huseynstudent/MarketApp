using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities;

public class Category:BaseEntity
{
    [MaxLength(100)]
    public string? Name { get; set; }
    public virtual List<Product>? Products { get; set; } // Navigation Property
}
