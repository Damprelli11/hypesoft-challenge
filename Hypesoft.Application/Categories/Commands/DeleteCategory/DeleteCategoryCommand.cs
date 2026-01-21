using MediatR;

namespace Hypesoft.Application.Categories.Commands.DeleteCategory;

/// <summary>
/// Represents a command to delete a category.
/// </summary>
/// <param name="Id">The identifier of the category to delete.</param>
public record DeleteCategoryCommand(Guid Id) : IRequest<Unit>;