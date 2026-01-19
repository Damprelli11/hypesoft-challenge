using MediatR;

namespace Hypesoft.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id) : IRequest;