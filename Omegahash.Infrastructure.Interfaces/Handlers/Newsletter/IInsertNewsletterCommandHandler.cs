using Omegahash.Domain.Serializations.Commands.Newsletter;

namespace Omegahash.Infrastructure.Interfaces.Handlers.Newsletter;

public interface IInsertNewsletterCommandHandler
{
    Task HandleAsync(InsertNewsletterCommand command, CancellationToken cancellationToken);
}
