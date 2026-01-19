using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        // TEMPORÁRIO (até integrar Mongo/EF)
        await Task.CompletedTask;
    }
}
