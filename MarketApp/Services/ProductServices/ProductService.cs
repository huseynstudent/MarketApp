namespace MarketApp.Services.ProductServices;

using MarketApp.Context;
using MarketApp.Entities;

public class ProductService : IProductService
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
        if (Product == null)
        {
            Console.WriteLine("product wasnt found");
            return;
        }
        Product.IsDeleted = true;
        Product.DeletedDate = DateTime.Now;
        Console.WriteLine("product was deleted");
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
        if (Product == null)
        {
            Console.WriteLine("Product wasnt found");
            return;
        }
        Product.UpdatedDate = DateTime.Now;
        Console.WriteLine("Enter new name:");
        string newName = Console.ReadLine();
        Product.Name = newName;
        Console.WriteLine("Enter new price:");
        float newPrice = float.Parse(Console.ReadLine());
        Product.Price = newPrice;
        _context.Products.Update(Product);
        Console.WriteLine("Product updated.");

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

                    var suppliers = _context.Suppliers.ToList();
                    if (suppliers.Count == 0)
                    {
                        Console.WriteLine("No suppliers found. returning null");
                        p.Supplier = null;
                        p.SupplierId = 0;
                        break;
                    }
                    Console.WriteLine("Select Supplier Id:");
                    foreach (var supplier in suppliers)
                    {
                        Console.WriteLine($"Id: {supplier.Id}, Name: {supplier.Name}");
                    }
                    int supplierId = 0;
                    while (!int.TryParse(Console.ReadLine(), out supplierId) || !suppliers.Any(s => s.Id == supplierId))
                    {
                        Console.WriteLine("Invalid Supplier Id. Please select a valid one.");
                    }
                    p.SupplierId = supplierId;

                    var orders = _context.Orders.ToList();
                    if (orders.Count == 0)
                    {
                        Console.WriteLine("No orders found. returning null");
                        p.Order = null;
                        p.OrderId = 0;
                        break;
                    }
                    Console.WriteLine("Select order Id:");
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Id: {order.Id}, Name: {order.OrderNumber}");
                    }
                    int orderId = 0;
                    while (!int.TryParse(Console.ReadLine(), out orderId) || !orders.Any(s => s.Id == orderId))
                    {
                        Console.WriteLine("Invalid order Id. Please select a valid one.");
                    }

                    p.OrderId = orderId;
                    var Categories = _context.Categories.ToList();
                    if (Categories.Count == 0)
                    {
                        Console.WriteLine("No Categories found. returning null");
                        p.Category = null;
                        p.CategoryId = 0;
                        break;
                    }
                    Console.WriteLine("Select Categorie Id:");
                    foreach (var Categorie in Categories)
                    {
                        Console.WriteLine($"Id: {Categorie.Id}, Name: {Categorie.Name}");
                    }
                    int CategorieId = 0;
                    while (!int.TryParse(Console.ReadLine(), out CategorieId) || !Categories.Any(s => s.Id == CategorieId))
                    {
                        Console.WriteLine("Invalid Categorie Id. Please select a valid one.");
                    }
                    p.CategoryId = CategorieId;
                    //var tags = _context.Tags.ToList();
                    //if (tags.Count > 0)
                    //{
                    //    Console.WriteLine("Select Tag Ids (comma separated, or leave empty for none):");
                    //    foreach (var tag in tags)
                    //    {
                    //        Console.WriteLine($"Id: {tag.Id}, Label: {tag.Label}");
                    //    }
                    //    string tagInput = Console.ReadLine();
                    //    if (!string.IsNullOrWhiteSpace(tagInput))
                    //    {
                    //        var tagIds = tagInput.Split(',')
                    //            .Select(t => int.TryParse(t.Trim(), out int id) ? id : (int?)null)
                    //            .Where(id => id.HasValue && tags.Any(tag => tag.Id == id.Value))
                    //            .Select(id => id.Value)
                    //            .ToList();
                    //        p.Tags = tags.Where(tag => tagIds.Contains(tag.Id)).ToList();
                    //    }
                    //    else
                    //    {
                    //        p.Tags = new List<Tag>();
                    //    }
                    //}
                    //else
                    //{
                    //    p.Tags = new List<Tag>();
                    //}

                    CreateProduct(p);
                    Console.WriteLine("Product added.");
                    break;


                case 2:
                    var products = _context.Products
                        .ToList();
                    if (products.Count == 0)
                    {
                        Console.WriteLine("No products found.");
                        break;
                    }
                    foreach (var product in products)
                    {
                        Console.WriteLine($"Id: {product.Id}, Name: {product.Name}");
                    }

                    Console.Write("Enter Product Id to delete: ");
                    DeleteProduct(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("Enter Product Id to update: ");
                    UpdateProduct(int.Parse(Console.ReadLine()));
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
