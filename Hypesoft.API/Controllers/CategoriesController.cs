using MediatR;
using Microsoft.AspNetCore.Mvc;

using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;

using Hypesoft.Application.DTOs;
using Hypesoft.Application.Categories.Commands.UpdateCategory;
using Hypesoft.Application.Categories.Commands.DeleteCategory;

namespace Hypesoft.API.Controllers;

/// <summary>
/// Controller for managing categories in the application.
/// Provides endpoints for CRUD operations on categories.
/// </summary>
[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoriesController"/> class.
    /// </summary>
    /// <param name="repository">The category repository for data access.</param>
    /// <param name="mediator">The mediator for handling commands and queries.</param>
    public CategoriesController(
        ICategoryRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of categories.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="request">The request containing the category name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created category.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);

        await _repository.AddAsync(category, cancellationToken);

        return CreatedAtAction(nameof(GetAll), category);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="request">The request containing the updated category name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content if successful.</returns>
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

    /// <summary>
    /// Deletes a category by ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content if successful.</returns>
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
