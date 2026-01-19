using Hypesoft.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Hypesoft.Infrastructure.Persistence.MongoMappings;

public static class ProductMap
{
    public static void Configure()
    {
        if (BsonClassMap.IsClassMapRegistered(typeof(Product)))
            return;

        BsonClassMap.RegisterClassMap<Product>(map =>
        {
            map.AutoMap();

            map.MapIdMember(p => p.Id)
               .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));

            map.MapMember(p => p.Name);
            map.MapMember(p => p.Description);
            map.MapMember(p => p.Price);
            map.MapMember(p => p.Category);
            map.MapMember(p => p.Stock);
            map.MapMember(p => p.CreatedAt);
        });
    }
}
