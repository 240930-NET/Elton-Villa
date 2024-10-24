using P1.API.Data;
using P1.API.Model;

namespace P1.API.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly MASHContext _mashContext;

    public CategoryRepository(MASHContext mashContext) => _mashContext = mashContext;

    public IEnumerable<Category> GetAllCategories()
    {
        return _mashContext.Categories.ToList();
    }

    public void AddCategory(Category category){
        _mashContext.Categories.Add(category);
    }
}