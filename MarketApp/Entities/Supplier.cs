using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities;

public class Supplier: BaseEntity
{
    [Required]
    [MaxLength(100)]    
    public string? Name { get; set; }
    public List<Product>? Products { get; set; } // Navigation Property
}
