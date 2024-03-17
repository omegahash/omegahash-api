using MongoDB.Driver;
using Omegahash.Data;

namespace Omegahash.Endpoints.Wallets.GetAll;

public static class Endpoint
{
    public static WebApplication MapGetAllWallets(this WebApplication app)
    {
        app.MapGet("/wallets", async (DataContext context) =>
        {
            try
            {
                var wallets = await context.Wallets.Find(_ => true).ToListAsync();
                return Results.Ok(wallets);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
        .WithName("GetAllWallets")
        .WithOpenApi();

        return app;
    }
}
