using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities;

public class Tag: BaseEntity
{
    [MaxLength(50)]
    public string? Label { get; set; }
    public List<Product>? Products { get; set; } // Navigation Property
}
