using MediatR;

namespace Hypesoft.Application.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductResponse?>
{
    public Guid Id { get; }

    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}
