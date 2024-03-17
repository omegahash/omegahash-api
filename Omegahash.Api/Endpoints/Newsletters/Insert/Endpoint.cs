using Microsoft.AspNetCore.Mvc;
using Omegahash.Domain.Serializations.Requests;
using Omegahash.Infrastructure.Interfaces.Handlers.Newsletter;

namespace Omegahash.Endpoints.Marketings.RegisterToNewsletter;
    
public static class Endpoint
{
    public static WebApplication MapNewsletterInsert(this WebApplication app)
    {
        app.MapPost("/newsletters", InsertAsync)
           .AddEndpointFilter<ValidationFilter>()
           .WithName("NewsletterInsert")
           .WithOpenApi();

        return app;
    }

    private static async Task<IResult> InsertAsync
    (
        [FromServices]IInsertNewsletterHandler handler,
        [FromBody]InsertNewsletterRequest request,
        CancellationToken cancellationToken
    )
    {
        await handler.HandleAsync(request, cancellationToken);

        return Results.NoContent();
    }
}
