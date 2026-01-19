using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products = new();

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

    public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(_products.AsEnumerable());
    }
}
