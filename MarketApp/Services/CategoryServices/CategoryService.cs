using MarketApp.Context;
using MarketApp.Entities;

namespace MarketApp.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    MarketDbContext _context;
    public CategoryService()
    {
        _context = new MarketDbContext();
    }
    public void CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            Console.WriteLine("category wasnt found");
            return;
        }
        category.IsDeleted = true;
        category.DeletedDate = DateTime.Now;
        Console.WriteLine("category was deleted");
        _context.SaveChanges();
    }

    public List<Category> GetAllCategories()
    {
        return _context.Categories.Where(c => !c.IsDeleted).ToList();
    }

    public Category GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }

    public void UpdateCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null) { 
            Console.WriteLine("Category wasn't found");
            return;
        }
        category.UpdatedDate = DateTime.Now;
        Console.WriteLine("Enter new name:");
        string newName = Console.ReadLine();
        category.Name = newName;
        _context.Categories.Update(category);
        Console.WriteLine("Category updated.");
        _context.SaveChanges();
    }

    public void CategoryMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCategory Menu:");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Delete Category");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Get Category By Id");
            Console.WriteLine("5. Get All Categories");
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Category c = new Category();
                    Console.Write("Name: ");
                    c.Name = Console.ReadLine();
                    CreateCategory(c);
                    Console.WriteLine("Category added.");
                    break;
                case 2:
                    Console.Write("Enter Category Id to delete: ");
                    DeleteCategory(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("Enter Category Id to update: ");
                    UpdateCategory(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.Write("Enter Category Id: ");
                    var category = GetCategoryById(int.Parse(Console.ReadLine()));
                    Console.WriteLine(category != null ? $"Id: {category.Id}, Name: {category.Name}" : "Not found.");
                    break;
                case 5:
                    var all = GetAllCategories();
                    foreach (var item in all)
                        Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
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
