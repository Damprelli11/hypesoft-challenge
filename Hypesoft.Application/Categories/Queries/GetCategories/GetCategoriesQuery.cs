using Hypesoft.Application.DTOs;
using MediatR;

namespace Hypesoft.Application.Categories.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<List<CategoryDto>>;