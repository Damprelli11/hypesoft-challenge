using MediatR;
using Hypesoft.Domain.Repositories;
using Hypesoft.Application.Products.Queries;

namespace Hypesoft.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, ProductResponse?>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse?> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (product is null)
            return null;

        product.Update(
            request.Name,
            request.Description,
            request.Price,
            request.Category,
            request.Stock
        );

        await _repository.UpdateAsync(product, cancellationToken);

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
