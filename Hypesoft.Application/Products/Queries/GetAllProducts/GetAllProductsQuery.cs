using MediatR;
using Hypesoft.Application.Products.Queries;

namespace Hypesoft.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery
    : IRequest<IEnumerable<ProductResponse>>;
