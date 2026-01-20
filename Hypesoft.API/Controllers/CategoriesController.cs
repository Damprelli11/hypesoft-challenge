using MediatR;
using Microsoft.AspNetCore.Mvc;

using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;

using Hypesoft.Application.DTOs;
using Hypesoft.Application.Categories.Commands.UpdateCategory;
using Hypesoft.Application.Categories.Commands.DeleteCategory;

namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;
    private readonly IMediator _mediator;

    public CategoriesController(
        ICategoryRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateCategoryCommand(id, request.Name),
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteCategoryCommand(id),
            cancellationToken);

        return NoContent();
    }
}
