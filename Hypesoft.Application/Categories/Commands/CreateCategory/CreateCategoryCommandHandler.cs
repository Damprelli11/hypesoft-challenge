using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using MediatR;

namespace Hypesoft.Application.Categories.Commands.CreateCategory;

/// <summary>
/// Handles the creation of a new category.
/// </summary>
public class CreateCategoryCommandHandler
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCategoryCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The category repository.</param>
    public CreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the create category command.
    /// </summary>
    /// <param name="request">The create category command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The identifier of the created category.</returns>
    public async Task<Guid> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);

        await _repository.AddAsync(category, cancellationToken);

        return category.Id;
    }
}
