using MediatR;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDto Product) : IRequest<Guid>;
