using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Omegahash.Infrastructure.Behaviors;
using Omegahash.Infrastructure.Handlers.Newsletter;

namespace Omegahash.Infrastructure;

public static class InfrastructureBuilder
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));
        services.AddTransient<InsertNewsletterCommandHandler>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

        return services;
    }
}
