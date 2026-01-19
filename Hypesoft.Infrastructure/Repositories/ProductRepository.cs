using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        // implementação fake por enquanto
        await Task.CompletedTask;
    }
}
