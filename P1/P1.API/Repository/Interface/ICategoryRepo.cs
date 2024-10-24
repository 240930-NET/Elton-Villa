using P1.API.Model;

namespace P1.API.Repository;

public interface ICategoryRepository
{
    public IEnumerable<Category> GetAllCategories();
    public void AddCategory(Category category);
}