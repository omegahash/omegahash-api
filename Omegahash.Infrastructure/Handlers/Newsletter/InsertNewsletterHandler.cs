using MongoDB.Bson;
using Omegahash.Domain.Serializations.Requests;
using Omegahash.Infrastructure.Data.Interfaces;
using Omegahash.Infrastructure.Interfaces.Handlers.Newsletter;

namespace Omegahash.Infrastructure.Handlers.Newsletter;

using Omegahash.Domain.Entities;

public class InsertNewsletterHandler(IMongoProvider provider) : IInsertNewsletterHandler
{
    public async Task HandleAsync(InsertNewsletterRequest command, CancellationToken cancellationToken)
    {
        var entity = new Newsletter
        {
            Id = ObjectId.GenerateNewId(),
            Email = command.Email,
            CreatedAt = DateTime.UtcNow,
        };

        await provider.Newsletters
                      .InsertOneAsync
                      (
                          document: entity,
                          cancellationToken: cancellationToken
                      );
    }
}
