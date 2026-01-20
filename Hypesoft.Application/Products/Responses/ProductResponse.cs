namespace Hypesoft.Application.Products.Responses;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    Guid CategoryId,
    string CategoryName,
    int Stock
);
