namespace MarketApp.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public float Price { get; set; }

        public int? CategoryId { get; set; } // Foreign Key
        public virtual Category? Category { get; set; } // Navigation Property
        public virtual ICollection<Order>? Orders { get; set; } // Navigation Property

    }
}
