using MediatR;

namespace Hypesoft.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    Guid CategoryId,
    int Stock
) : IRequest<Guid>;
