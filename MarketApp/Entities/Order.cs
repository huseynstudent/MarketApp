namespace MarketApp.Entities;

public class Order:BaseEntity
{
    public string? OrderNumber { get; set; }
    public ICollection<Product>? Products { get; set; }
}
