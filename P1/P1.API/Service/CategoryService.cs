using Microsoft.AspNetCore.Components.Web;
using P1.API.Model;
using P1.API.Model.DTO;
using P1.API.Repository;

namespace P1.API.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public List<Category> GetAllCategories()
    {
        return _categoryRepository.GetAllCategories();
    }

    public Category GetCategoryById(int id){
        Category category = _categoryRepository.GetCategoryById(id);
        if(category == null){
            throw new Exception($"The category with id: {id} does not exist.");
        }
        return category;
    }

    public void AddCategory(NewCategoryDTO categoryDTO, int gameId){
        if(categoryDTO.Title == "" || categoryDTO.Title == null){
            throw new Exception("Category cannot be added due to missing title.");
        }
        else if(categoryDTO.Options == null || categoryDTO.Options.Count == 0){
            throw new Exception("Category cannot be added. It must contain at least one option.");
        }

        Category category = new Category();
        category.Title = categoryDTO.Title;
        category.Options = categoryDTO.Options;
        category.GameId = gameId;

        _categoryRepository.AddCategory(category);
    }

    public void DeleteCategoryById(int id){
        Category categoryToDelete = _categoryRepository.GetCategoryById(id);
        if(categoryToDelete == null){
            throw new Exception($"The category with id: {id} does not exist and cannot be deleted.");
        }
        _categoryRepository.DeleteCategory(categoryToDelete);
    }
}