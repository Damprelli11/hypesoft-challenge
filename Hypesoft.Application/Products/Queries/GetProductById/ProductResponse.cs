namespace Hypesoft.Application.Products.Queries.GetProductById;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string Category,
    int Stock
);
