using Microsoft.Extensions.DependencyInjection;
using Omegahash.Infrastructure.Data.Interfaces;
using Omegahash.Infrastructure.Data.Services;

namespace Omegahash.Infrastructure.Data;

public static class InfrastructureDataBuilder
{
    public static IServiceCollection AddDataProviders(this IServiceCollection services)
    {
        services.AddScoped<IMongoProvider, MongoProvider>();

        return services;
    }
}
