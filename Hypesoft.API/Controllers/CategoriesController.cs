using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public CategoriesController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);

        await _repository.AddAsync(category, cancellationToken);

        return CreatedAtAction(nameof(GetAll), category);
    }
}

public record CreateCategoryRequest(string Name);
