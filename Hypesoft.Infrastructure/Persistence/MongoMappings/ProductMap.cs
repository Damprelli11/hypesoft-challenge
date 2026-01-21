using Hypesoft.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Hypesoft.Infrastructure.Persistence.MongoMappings;

/// <summary>
/// Configures BSON mapping for the Product entity.
/// </summary>
public static class ProductMap
{
    /// <summary>
    /// Registers the BSON class map for Product if not already registered.
    /// Maps all properties and sets the Id as the document identifier with standard GUID representation.
    /// </summary>
    public static void Configure()
    {
        if (BsonClassMap.IsClassMapRegistered(typeof(Product)))
            return;

        BsonClassMap.RegisterClassMap<Product>(map =>
        {
            map.MapIdMember(p => p.Id)
               .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));

            map.MapMember(p => p.Name);
            map.MapMember(p => p.Description);
            map.MapMember(p => p.Price);
            map.MapMember(p => p.CategoryId);
            map.MapMember(p => p.Stock);
            map.MapMember(p => p.CreatedAt);
        });
    }
}
