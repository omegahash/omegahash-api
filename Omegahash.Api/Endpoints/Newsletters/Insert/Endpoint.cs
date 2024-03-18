using Microsoft.AspNetCore.Mvc;
using Omegahash.Infrastructure.Commands.Newsletter;
using Omegahash.Infrastructure.Handlers.Newsletter;

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
        [FromServices]InsertNewsletterCommandHandler handler,
        [FromBody]InsertNewsletterCommand request,
        CancellationToken cancellationToken
    )
    {
        await handler.Handle(request, cancellationToken);
        
        return Results.NoContent();
    }
}
