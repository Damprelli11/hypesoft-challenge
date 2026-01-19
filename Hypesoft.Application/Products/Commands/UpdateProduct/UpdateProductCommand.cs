using MediatR;
using Hypesoft.Application.Products.Responses;

namespace Hypesoft.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string Category,
    int Stock
) : IRequest<ProductResponse?>;
