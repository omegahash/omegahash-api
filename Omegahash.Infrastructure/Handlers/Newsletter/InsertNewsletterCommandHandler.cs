using FluentValidation;
using MediatR;
using MongoDB.Bson;
using Omegahash.Infrastructure.Commands.Newsletter;
using Omegahash.Infrastructure.Data.Interfaces;

namespace Omegahash.Infrastructure.Handlers.Newsletter;

using Omegahash.Domain.Entities;

public class InsertNewsletterCommandHandler(IMongoProvider provider, IValidator<InsertNewsletterCommand> validator) : IRequestHandler<InsertNewsletterCommand>
{
    public async Task Handle(InsertNewsletterCommand command, CancellationToken cancellationToken)
    {
        validator.ValidateAndThrow(command);

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
