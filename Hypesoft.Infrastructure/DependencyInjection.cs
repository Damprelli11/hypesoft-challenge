using Microsoft.Extensions.DependencyInjection;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Repositories;

namespace Hypesoft.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton(new List<Product>());
        services.AddSingleton<IProductRepository, ProductRepository>();

        return services;
    }
}
