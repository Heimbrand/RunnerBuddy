using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RunnerBuddy.Api.EndpointRegistration;

public static class EndpointRegistration
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] serviceDescriptors = assembly
            .DefinedTypes
            .Where(t => t is { IsAbstract: false, IsInterface: false } && t
                .IsAssignableFrom(typeof(IEndpoint)))
            .Select(t => ServiceDescriptor.Transient(typeof(IEndpoint), t)).ToArray();

        services.TryAddEnumerable(serviceDescriptors);
        return services;
    }
    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IEndpoint> enpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (IEndpoint endpoint in enpoints)
        {
            endpoint.MapEndpoints(builder);
        }
        return app;
    }
}