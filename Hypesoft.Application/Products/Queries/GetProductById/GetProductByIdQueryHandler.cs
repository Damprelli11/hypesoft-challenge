using MediatR;
using Hypesoft.Domain.Repositories;
using Hypesoft.Application.Products.Responses;

namespace Hypesoft.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, ProductResponse?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return null;

        return new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Category,
            product.Stock
        );
    }
}
