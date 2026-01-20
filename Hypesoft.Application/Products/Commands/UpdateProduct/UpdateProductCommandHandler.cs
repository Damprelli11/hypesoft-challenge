using MediatR;
using Hypesoft.Domain.Repositories;
using Hypesoft.Application.Products.Responses;

namespace Hypesoft.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, ProductResponse?>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateProductCommandHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ProductResponse?> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (product is null)
            return null;

        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Category not found");
        }

        product.Update(
            request.Name,
            request.Description,
            request.Price,
            request.CategoryId,
            request.Stock
        );

        await _productRepository.UpdateAsync(product, cancellationToken);

        return new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.CategoryId,
            category.Name,
            product.Stock
        );
    }
}
