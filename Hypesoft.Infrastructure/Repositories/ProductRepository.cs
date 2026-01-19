using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult<IReadOnlyList<Product>>(_products);
    }

    public Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);

        if (index >= 0)
            _products[index] = product;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is not null)
            _products.Remove(product);

        return Task.CompletedTask;
    }
}
