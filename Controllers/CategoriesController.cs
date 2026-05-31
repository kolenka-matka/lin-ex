using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers;

// Контроллер №2 (для модели Category)
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private static readonly List<Category> _categories = new()
    {
        new Category { Id = 1, Title = "Electronics" },
        new Category { Id = 2, Title = "Accessories" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Category>> GetAll() => Ok(_categories);

    [HttpGet("{id}")]
    public ActionResult<Category> GetById(int id)
    {
        var category = _categories.FirstOrDefault(c => c.Id == id);
        return category is null ? NotFound() : Ok(category);
    }

    [HttpPost]
    public ActionResult<Category> Create(Category category)
    {
        category.Id = _categories.Count == 0 ? 1 : _categories.Max(c => c.Id) + 1;
        _categories.Add(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }
}
