using System.ComponentModel.DataAnnotations.Schema;

namespace MarketApp.Entities;

public class Order:BaseEntity
{
    public string? OrderNumber { get; set; }
    public List<Product>? Products { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
}
