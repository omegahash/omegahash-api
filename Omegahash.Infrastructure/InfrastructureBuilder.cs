using Microsoft.Extensions.DependencyInjection;
using Omegahash.Infrastructure.Handlers.Newsletter;
using Omegahash.Infrastructure.Interfaces.Handlers.Newsletter;

namespace Omegahash.Infrastructure;

public static class InfrastructureBuilder
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<IInsertNewsletterHandler, InsertNewsletterHandler>();

        return services;
    }
}
