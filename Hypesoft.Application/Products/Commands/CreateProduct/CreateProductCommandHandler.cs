public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Product.Name,
            request.Product.Description,
            request.Product.Price,
            request.Product.Category,
            request.Product.Stock
        );

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;
    }
}
