using MongoDB.Driver;
using Omegahash.Domain.Entities;

namespace Omegahash.Infrastructure.Data.Interfaces;

public interface IMongoProvider
{
    IMongoCollection<Newsletter> Newsletters { get; }
}
