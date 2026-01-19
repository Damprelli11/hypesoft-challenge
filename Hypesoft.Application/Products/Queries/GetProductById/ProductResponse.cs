namespace Hypesoft.Application.Products.Queries;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string Category,
    int Stock
);
