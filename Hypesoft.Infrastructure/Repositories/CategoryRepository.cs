using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Persistence;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for category operations using MongoDB.
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _collection;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="context">The MongoDB context.</param>
    public CategoryRepository(MongoContext context)
    {
        _collection = context.Categories;
    }

    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of all categories.</returns>
    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection
            .Find(_ => true)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a category by its ID.
    /// </summary>
    /// <param name="id">The category ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The category if found, otherwise null.</returns>
    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Adds a new category to the database.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task AddAsync(Category category, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(category, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Updates an existing category in the database.
    /// </summary>
    /// <param name="category">The category to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task UpdateAsync(Category category, CancellationToken cancellationToken)
    {
        var filter = Builders<Category>.Filter.Eq(x => x.Id, category.Id);
        await _collection.ReplaceOneAsync(filter, category, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="id">The category ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<Category>.Filter.Eq(x => x.Id, id);
        await _collection.DeleteOneAsync(filter, cancellationToken);
    }
}