using MediatR;
using Hypesoft.Application.Commands.CreateProduct;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Product;

        var product = new Product(
            dto.Name,
            dto.Description,
            dto.Price,
            dto.Category,
            dto.Stock
        );

        await _repository.AddAsync(product);

        return product.Id;
    }
}
