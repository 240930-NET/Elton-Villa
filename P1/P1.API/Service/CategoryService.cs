using P1.API.Model;
using P1.API.Repository;

namespace P1.API.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public IEnumerable<Category> GetAllCategories()
    {
        return _categoryRepository.GetAllCategories();
    }

    public void AddCategory(Category category){
        if(category.Title == "" || category.Title == null){
            throw new Exception("Category cannot be added due to missing title.");
        }
        else if(category.Options == null || category.Options.Count == 0){
            throw new Exception("Category cannot be added. It must contain at least one option.");
        }
        //Add another check for valid game id and game
        _categoryRepository.AddCategory(category);
    }
}