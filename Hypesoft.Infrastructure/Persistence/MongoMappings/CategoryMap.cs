using Hypesoft.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Hypesoft.Infrastructure.Persistence.MongoMappings;

public static class CategoryMap
{
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