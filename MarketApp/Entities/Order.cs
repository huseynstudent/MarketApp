namespace MarketApp.Entities;

public class Order:BaseEntity
{
    public string? OrderNumber { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}
