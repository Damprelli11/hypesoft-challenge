using Hypesoft.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Hypesoft.Infrastructure.Persistence.MongoMappings;

/// <summary>
/// Configures BSON mapping for the Category entity.
/// </summary>
public static class CategoryMap
{
    /// <summary>
    /// Registers the BSON class map for Category if not already registered.
    /// Maps the Id property as the document identifier.
    /// </summary>
    public static void Configure()
    {
        if (BsonClassMap.IsClassMapRegistered(typeof(Category)))
            return;

        BsonClassMap.RegisterClassMap<Category>(map =>
        {
            map.AutoMap();
            map.MapIdMember(c => c.Id);
        });
    }
}