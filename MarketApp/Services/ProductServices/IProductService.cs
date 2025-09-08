using MarketApp.Entities;

namespace MarketApp.Services.ProductServices;

internal interface IProductService
{
    public void CreateProduct(Product Product);
    public List<Product> GetAllProducts();
    public Product GetProductById(int id);
    public void UpdateProduct(int id);
    public void DeleteProduct(int id);
}
