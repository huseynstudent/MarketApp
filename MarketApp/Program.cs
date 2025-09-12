using MarketApp.Context;
using MarketApp.Entities;
namespace MarketApp;
//1.Login Registration
//3.fluent api istifade olunmali
//4.Configuration classlara cixmalidir 
//7.Add Delete Update getById GetAll
//8.Butun kodlama service mentiqleri le yazilmalidir

//1.Registration ucun gmaile OTP
//2.ForgetPassword 
//3.Paswordler Hashleme ile database yazilib oxunmasi


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

    }
}
