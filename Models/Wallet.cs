using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Omegahash.Attributes;

namespace Omegahash.Models;

[BsonCollection("wallets")]
public struct Wallet
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string WalletId { get; set; }

    [BsonElement("address")]
    public string Address { get; set; }
}