using Hypesoft.Domain.Entities;
using Hypesoft.Infrastructure.Persistence.MongoMappings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace Hypesoft.Infrastructure.Persistence;

/// <summary>
/// Provides access to MongoDB collections for products and categories.
/// Configures BSON serialization and mappings.
/// </summary>
public class MongoContext
{
    /// <summary>
    /// Gets the MongoDB collection for products.
    /// </summary>
    public IMongoCollection<Product> Products { get; }

    /// <summary>
    /// Gets the MongoDB collection for categories.
    /// </summary>
    public IMongoCollection<Category> Categories { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MongoContext"/> class.
    /// Sets up MongoDB client, database, and collection mappings.
    /// </summary>
    /// <param name="options">The MongoDB settings options.</param>
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
