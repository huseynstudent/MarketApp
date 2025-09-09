using MarketApp.Context;
using MarketApp.Entities;

namespace MarketApp;

internal class Program
{
    static void Main(string[] args)
    {
        MarketDbContext context = new MarketDbContext();

        Category category1 = new Category() { Name = "Elektronika" };
        Category category2 = new Category() { Name = "Mebel" };
        Category category3 = new Category() { Name = "Neqliyyat" };

        Product product1 = new Product() { Name = "Televizor", Price = 1500, Category = category1 };
        Product product2 = new Product() { Name = "Ayfon", Price = 2500, Category = category1 };
        Product product3 = new Product() { Name = "Blender", Price = 500, Category = category1 };
        Product product4 = new Product() { Name = "Kreslo", Price = 300, Category = category2 };
        Product product5 = new Product() { Name = "Skuter", Price = 1200, Category = category3 };
        context.Categories.AddRange(category1, category2, category3);
        context.Products.AddRange(product1, product2, product3);

        context.Products.AddRange(product4, product5);

        context.SaveChanges();

        var products = context.Products.ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id} - {product.Name} - {product.Price} - {product.Category?.Name}");
        }
        Console.WriteLine("---------------------------------------------------");
        var category = context.Categories.ToList();
        foreach (var cat in category)
        {
            Console.WriteLine($"{cat.Id} - {cat.Name}");
            foreach (var prod in cat.Products)
            {
                Console.WriteLine($" {prod.Id} - {prod.Name} - {prod.Price}");
            }
        }

    }
}
