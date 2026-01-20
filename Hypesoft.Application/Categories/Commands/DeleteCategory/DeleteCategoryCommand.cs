using MediatR;

namespace Hypesoft.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid Id) : IRequest<Unit>;