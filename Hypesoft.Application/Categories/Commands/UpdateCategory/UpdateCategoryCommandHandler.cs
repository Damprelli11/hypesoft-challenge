using MediatR;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler
    : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(
        UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (category is null)
            throw new Exception("Categoria não encontrada");

        category.Rename(request.Name);

        await _repository.UpdateAsync(category, cancellationToken);

        return Unit.Value;
    }
}
