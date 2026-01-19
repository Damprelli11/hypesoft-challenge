using MediatR;
using Hypesoft.Domain.Repositories;
using Hypesoft.Application.Products.Responses;

namespace Hypesoft.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler
    : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductResponse>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products.Select(product => new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Category,
            product.Stock
        ));
    }
}
