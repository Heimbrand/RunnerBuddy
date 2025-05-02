using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RunnerBuddy.Application;

public static class ServiceRegistration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
    }
}

