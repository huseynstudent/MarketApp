using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketApp.Entities
{
    public class Product : BaseEntity
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        [Range(0.1, 1000.00)]
        [Required]
        public float Price { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; } // Foreign Key
        public Category? Category { get; set; } // Navigation Property
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order? Order { get; set; } // Navigation Property

        public List<Tag>? Tags { get; set; } // Navigation Property

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; } // Foreign Key
        public Supplier? Supplier { get; set; } // Navigation Property
    }
}
