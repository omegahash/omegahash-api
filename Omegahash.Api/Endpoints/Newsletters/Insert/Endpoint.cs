using Microsoft.AspNetCore.Mvc;
using Omegahash.Domain.Serializations.Commands;
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
        [FromServices]IInsertNewsletterHandler handler,
        [FromBody]InsertNewsletterCommand request,
        CancellationToken cancellationToken
    )
    {
        await handler.HandleAsync(request, cancellationToken);

        return Results.NoContent();
    }
}
