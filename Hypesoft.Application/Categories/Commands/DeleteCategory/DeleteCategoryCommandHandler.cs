using MediatR;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (category is null)
            throw new Exception("Categoria não encontrada");

        await _repository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}