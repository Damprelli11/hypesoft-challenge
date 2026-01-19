using MediatR;

namespace Hypesoft.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    string Category,
    int Stock
) : IRequest<Guid>;
