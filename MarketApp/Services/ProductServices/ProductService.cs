namespace MarketApp.Services.ProductServices;

using MarketApp.Context;
using MarketApp.Entities;

public class ProductService: IProductService
{
    MarketDbContext _context;
    public void CreateProduct(Product Product)
    {
        _context.Products.Add(Product);
    }

    public void DeleteProduct(int id)
    {
        var Product = _context.Products.Find(id);
        if (Product != null)

        {
            Product.IsDeleted = true;
            Product.DeletedDate = DateTime.Now;
        }
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
    }
}
