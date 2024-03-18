using Microsoft.AspNetCore.Mvc;
using Omegahash.Domain.Serializations;
using Omegahash.Domain.Serializations.Commands.Newsletter;
using Omegahash.Infrastructure.Interfaces.Handlers.Newsletter;

namespace Omegahash.Endpoints.Marketings.RegisterToNewsletter;

public static class Endpoint
{
    public static WebApplication MapNewsletterInsert(this WebApplication app)
    {
        app.MapPost("/newsletters", InsertAsync)
           .WithName("NewsletterInsert")
           .WithOpenApi();

        return app;
    }

    private static async Task<IResult> InsertAsync
    (
        [FromServices]IInsertNewsletterCommandHandler handler,
        [FromBody]InsertNewsletterCommand request,
        CancellationToken cancellationToken
    )
    {
        await handler.HandleAsync(request, cancellationToken);
        
        return Results.NoContent();
    }
}
