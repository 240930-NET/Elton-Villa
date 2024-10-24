using P1.API.Model;
using P1.API.Model.DTO;

namespace P1.API.Service;

public interface ICategoryService
{
    public List<Category> GetAllCategories();
    public Category GetCategoryById(int id);
    public void AddCategory(NewCategoryDTO categoryDTO, int gameId);
    public void DeleteCategoryById(int id);
}