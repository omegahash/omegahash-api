using Omegahash.Data;
using Omegahash.Models;

namespace Omegahash.Endpoints.Wallets.Add;

public static class Endpoint
{
    public static WebApplication MapAddWallet(this WebApplication app)
    {
        app.MapPost("/wallets", async (Wallet wallet, CancellationToken cancellationToken, DataContext context) =>
        {
            try
            {
                await context.Wallets.InsertOneAsync(document: wallet, cancellationToken: cancellationToken);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
        .WithName("AddWallets")
        .WithOpenApi();

        return app;
    }
}
