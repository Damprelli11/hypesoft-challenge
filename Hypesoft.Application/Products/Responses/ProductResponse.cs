namespace Hypesoft.Application.Products.Responses;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string Category,
    int Stock
);
