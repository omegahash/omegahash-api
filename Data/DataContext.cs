using MongoDB.Driver;
using Omegahash.Models;

namespace Omegahash.Data;

public class DataContext(IMongoClient client)
{
    private readonly IMongoDatabase database = client.GetDatabase("omegahash");

    public IMongoCollection<Wallet> Wallets => database.GetCollection<Wallet>("wallets");
}
