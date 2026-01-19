using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Persistence;
using Hypesoft.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hypesoft.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(
            configuration.GetSection("MongoDb"));

        services.AddSingleton<MongoContext>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
