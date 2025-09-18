using MarketApp.Context;
using MarketApp.Entities;

namespace MarketApp.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    MarketDbContext _context;
    public void CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
        }
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
        if (category != null)
        {
            category.UpdatedDate = DateTime.Now;
            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();
            category.Name = newName;
            _context.Categories.Update(category);
        }
        _context.SaveChanges();
    }

}
