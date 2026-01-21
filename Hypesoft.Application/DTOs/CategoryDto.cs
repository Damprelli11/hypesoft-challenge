namespace Hypesoft.Application.DTOs;

/// <summary>
/// Represents a data transfer object for category information.
/// </summary>
/// <param name="Id">The unique identifier of the category.</param>
/// <param name="Name">The name of the category.</param>
public record CategoryDto(
    Guid Id,
    string Name
);

/// <summary>
/// Represents a request to create a new category.
/// </summary>
/// <param name="Name">The name of the category to create.</param>
public record CreateCategoryRequest(string Name);

/// <summary>
/// Represents a request to update an existing category.
/// </summary>
public class UpdateCategoryRequest
{
    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}