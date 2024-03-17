using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Omegahash.Shared.Attributes;

namespace Omegahash.Domain.Entities;

[BsonCollection("newsletters")]
public struct Newsletter
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public ObjectId Id { get; set; }

    [BsonElement("address")]
    public string Email { get; set; }

    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; }
}
