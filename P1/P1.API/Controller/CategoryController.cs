using Microsoft.AspNetCore.Mvc;
using P1.API.Model;
using P1.API.Model.DTO;
using P1.API.Service;

namespace P1.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

    [HttpGet("GetCategories")]
    public IActionResult GetAllCategories()
    {
        try{
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }
        catch(Exception e){
            return BadRequest("Could not get all categories: " + e.Message);
        }
    }

    [HttpGet("GetCategory/{id}")]
    public IActionResult GetCategoryById(int id)
    {
        try{
            var category = _categoryService.GetCategoryById(id);
            return Ok(category);
        }
        catch(Exception e){
            return BadRequest("Could not get category: " + e.Message);
        }

    }

    [HttpPost("AddCategory/{gameid}")]
    public IActionResult AddCategory([FromBody] NewCategoryDTO categoryDTO, int gameid){

        try{
            _categoryService.AddCategory(categoryDTO, gameid);
            return Ok("Category added.");
        }
        catch(Exception e){
            return BadRequest("Could not add category: " + e.Message);
        }
    }

    [HttpDelete("DeleteCategory/{id}")]
    public IActionResult DeleteCategoryById(int id){
        try{
            _categoryService.DeleteCategoryById(id);
            return Ok("Category deleted.");
        }
        catch(Exception e){
            return BadRequest("Could not delete category: " + e.Message);
        }
    }
}