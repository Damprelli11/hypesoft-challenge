using MediatR;
using Hypesoft.Application.Products.Responses;

namespace Hypesoft.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery
    : IRequest<IEnumerable<ProductResponse>>;
