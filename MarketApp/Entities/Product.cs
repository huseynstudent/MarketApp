using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public float Price { get; set; }

        public int? CategoryId { get; set; } // Foreign Key
        public Category? Category { get; set; } // Navigation Property
        public ICollection<Order>? Orders { get; set; } // Navigation Property

    }
}
