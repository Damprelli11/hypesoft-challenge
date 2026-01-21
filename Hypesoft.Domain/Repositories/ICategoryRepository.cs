using Hypesoft.Domain.Entities;

namespace Hypesoft.Domain.Repositories;

/// <summary>
/// Defines the contract for category repository operations.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves all categories asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of categories.</returns>
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a category by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The category if found; otherwise, null.</returns>
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Adds a new category asynchronously.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task AddAsync(Category category, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing category asynchronously.
    /// </summary>
    /// <param name="category">The category to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task UpdateAsync(Category category, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a category by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
