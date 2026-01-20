using Hypesoft.Domain.Entities;
using Hypesoft.Infrastructure.Persistence.MongoMappings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace Hypesoft.Infrastructure.Persistence;

public class MongoContext
{
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<Category> Categories { get; }

    public MongoContext(IOptions<MongoDbSettings> options)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        var settings = options.Value;

        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        ProductMap.Configure();
        CategoryMap.Configure();

        Products = database.GetCollection<Product>("products");
        Categories = database.GetCollection<Category>("categories");
    }
}
