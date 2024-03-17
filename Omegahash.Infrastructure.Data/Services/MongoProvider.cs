using MongoDB.Driver;
using Omegahash.Domain.Entities;
using Omegahash.Infrastructure.Data.Interfaces;

namespace Omegahash.Infrastructure.Data.Services;

public class MongoProvider(IMongoClient client) : IMongoProvider
{
    private readonly IMongoDatabase database = client.GetDatabase("omegahash");

    public IMongoCollection<Newsletter> Newsletters => database.GetCollection<Newsletter>(nameof(Newsletter).ToLower());
}
