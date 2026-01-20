namespace Hypesoft.Application.DTOs;

public record CategoryDto(
    Guid Id,
    string Name
);

public record CreateCategoryRequest(string Name);
public class UpdateCategoryRequest
{
    public string Name { get; set; } = string.Empty;
}