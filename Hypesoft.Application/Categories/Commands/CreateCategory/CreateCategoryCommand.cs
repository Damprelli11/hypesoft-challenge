using MediatR;

namespace Hypesoft.Application.Categories.Commands.CreateCategory;

/// <summary>
/// Represents a command to create a new category.
/// </summary>
/// <param name="Name">The name of the category to create.</param>
public record CreateCategoryCommand(string Name) : IRequest<Guid>;