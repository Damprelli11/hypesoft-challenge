using MediatR;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Categories.Commands.DeleteCategory;

/// <summary>
/// Handles the deletion of a category.
/// </summary>
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteCategoryCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The category repository.</param>
    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the delete category command.
    /// </summary>
    /// <param name="request">The delete category command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A unit value indicating the operation completed.</returns>
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (category is null)
            throw new Exception("Category not found");

        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}