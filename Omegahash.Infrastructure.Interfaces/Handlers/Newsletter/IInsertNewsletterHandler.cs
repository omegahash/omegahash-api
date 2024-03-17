using Omegahash.Domain.Serializations.Requests;

namespace Omegahash.Infrastructure.Interfaces.Handlers.Newsletter;

public interface IInsertNewsletterHandler
{
    Task HandleAsync(InsertNewsletterRequest command, CancellationToken cancellationToken);
}
