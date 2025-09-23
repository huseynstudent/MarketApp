namespace MarketApp.Services.ProductServices;

using MarketApp.Context;
using MarketApp.Entities;

public class ProductService: IProductService
{
    MarketDbContext _context;
    public ProductService()
    {
        _context = new MarketDbContext();
    }
    public void CreateProduct(Product Product)
    {
        _context.Products.Add(Product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var Product = _context.Products.Find(id);
        if (Product != null)

        {
            Product.IsDeleted = true;
            Product.DeletedDate = DateTime.Now;
        }
        _context.SaveChanges();
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products.Where(c => !c.IsDeleted).ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.Products.Find(id);
    }

    public void UpdateProduct(int id)
    {
        var Product = _context.Products.Find(id);
        if (Product != null)
        {
            Product.UpdatedDate = DateTime.Now;
            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();
            Product.Name = newName;
            Console.WriteLine("Enter new price:");
            float newPrice = float.Parse(Console.ReadLine());
            Product.Price = newPrice;
            _context.Products.Update(Product);
        }
        _context.SaveChanges();
    }

    public void ProductMenu()
    {
        while (true)
        {
            Console.WriteLine("\nProduct Menu:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Delete Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Get Product By Id");
            Console.WriteLine("5. Get All Products");
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Product p = new Product();
                    Console.Write("Name: ");
                    p.Name = Console.ReadLine();
                    Console.Write("Price: ");
                    p.Price = float.Parse(Console.ReadLine());
                    CreateProduct(p);
                    Console.WriteLine("Product added.");
                    break;
                case 2:
                    Console.Write("Enter Product Id to delete: ");
                    DeleteProduct(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Product deleted.");
                    break;
                case 3:
                    Console.Write("Enter Product Id to update: ");
                    UpdateProduct(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Product updated.");
                    break;
                case 4:
                    Console.Write("Enter Product Id: ");
                    var prod = GetProductById(int.Parse(Console.ReadLine()));
                    Console.WriteLine(prod != null ? $"Id: {prod.Id}, Name: {prod.Name}, Price: {prod.Price}" : "Not found.");
                    break;
                case 5:
                    var all = GetAllProducts();
                    foreach (var item in all)
                        Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}");
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
