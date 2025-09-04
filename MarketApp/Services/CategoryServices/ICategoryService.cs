using MarketApp.Entities;

namespace MarketApp.Services.CategoryServices;

interface ICategoryService
{
    public void CreateCategory(Category category);
    public List<Category> GetAllCategories();
    public Category GetCategoryById(int id);
    public void UpdateCategory(int id);
    public void DeleteCategory(int id);

}
