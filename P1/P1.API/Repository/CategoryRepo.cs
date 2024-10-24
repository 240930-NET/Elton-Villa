using P1.API.Data;
using P1.API.Model;

namespace P1.API.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly MASHContext _mashContext;

    public CategoryRepository(MASHContext mashContext) => _mashContext = mashContext;

    public List<Category> GetAllCategories()
    {
        return _mashContext.Categories.ToList();
    }

    public Category GetCategoryById(int id)
    {
        return _mashContext.Categories.Find(id);
    }

    public void AddCategory(Category category){
        _mashContext.Categories.Add(category);
        _mashContext.SaveChanges();
    }

    public void DeleteCategory(Category category){
        _mashContext.Categories.Remove(category);
        _mashContext.SaveChanges();
    }
}