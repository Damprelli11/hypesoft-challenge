using Hypesoft.Domain.Repositories;
using Hypesoft.Domain.Entities;
using Hypesoft.Infrastructure.Persistence;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for product operations using MongoDB.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="context">The MongoDB context.</param>
    public ProductRepository(MongoContext context)
    {
        _collection = context.Products;
    }

    /// <summary>
    /// Adds a new product to the database.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(product, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The product ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The product if found, otherwise null.</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);

    /// <summary>
    /// Retrieves all products from the database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An enumerable collection of all products.</returns>
    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        => await _collection.Find(_ => true).ToListAsync(cancellationToken);

    /// <summary>
    /// Updates an existing product in the database.
    /// </summary>
    /// <param name="product">The product to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        => await _collection.ReplaceOneAsync(p => p.Id == product.Id, product, cancellationToken: cancellationToken);

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="id">The product ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await _collection.DeleteOneAsync(p => p.Id == id, cancellationToken);
}
