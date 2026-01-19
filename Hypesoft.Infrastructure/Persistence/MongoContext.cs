using Hypesoft.Domain.Entities;
using Hypesoft.Infrastructure.Persistence.MongoMappings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Persistence;

public class MongoContext
{
    public IMongoCollection<Product> Products { get; }

    public MongoContext(IOptions<MongoDbSettings> options)
    {
        var settings = options.Value;

        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        ProductMap.Configure();

        Products = database.GetCollection<Product>("products");
    }
}
