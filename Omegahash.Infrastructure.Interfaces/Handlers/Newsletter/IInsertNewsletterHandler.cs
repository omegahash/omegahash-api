using Omegahash.Domain.Serializations.Commands;

namespace Omegahash.Infrastructure.Interfaces.Handlers.Newsletter;

public interface IInsertNewsletterHandler
{
    Task HandleAsync(InsertNewsletterCommand command, CancellationToken cancellationToken);
}
