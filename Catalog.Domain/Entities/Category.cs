using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogService.Domain.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation((BsonType.ObjectId))]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
