using Microsoft.AspNetCore.Mvc;
using P1.API.Model;
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
        var categories = _categoryService.GetAllCategories();
        return Ok(categories);
    }

    [HttpPost("AddCategory")]
    public IActionResult AddCategory([FromBody] Category category){

        try{
            _categoryService.AddCategory(category);
            return Ok(category);
        }
        catch(Exception e){
            return BadRequest("Could not add category: " + e.Message);
        }
    }
}