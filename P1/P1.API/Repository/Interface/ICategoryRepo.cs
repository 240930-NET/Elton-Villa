using P1.API.Model;

namespace P1.API.Repository;

public interface ICategoryRepository
{
    public List<Category> GetAllCategories();
    public Category GetCategoryById(int id);
    public void AddCategory(Category category);
    public void DeleteCategory(Category category);
}