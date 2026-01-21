using Hypesoft.Domain.Entities;

namespace Hypesoft.Domain.Repositories;

/// <summary>
/// Defines the contract for product repository operations.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves a product by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The product if found; otherwise, null.</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves all products asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An enumerable collection of products.</returns>
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Adds a new product asynchronously.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task AddAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing product asynchronously.
    /// </summary>
    /// <param name="product">The product to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task UpdateAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a product by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The product identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}