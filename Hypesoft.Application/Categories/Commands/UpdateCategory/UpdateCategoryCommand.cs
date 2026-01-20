using MediatR;

namespace Hypesoft.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    Guid Id,
    string Name
) : IRequest<Unit>;