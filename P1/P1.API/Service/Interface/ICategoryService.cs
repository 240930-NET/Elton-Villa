using P1.API.Model;

namespace P1.API.Service;

public interface ICategoryService
{
    public IEnumerable<Category> GetAllCategories();
    public void AddCategory(Category category);
}