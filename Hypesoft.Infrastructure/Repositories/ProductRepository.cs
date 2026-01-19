using Hypesoft.Domain.Repositories;
using Hypesoft.Domain.Entities;
using Hypesoft.Infrastructure.Persistence;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    public ProductRepository(MongoContext context)
    {
        _collection = context.Products;
    }
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(product, cancellationToken: cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        => await _collection.Find(_ => true).ToListAsync(cancellationToken);

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        => await _collection.ReplaceOneAsync(p => p.Id == product.Id, product, cancellationToken: cancellationToken);

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await _collection.DeleteOneAsync(p => p.Id == id, cancellationToken);
}
