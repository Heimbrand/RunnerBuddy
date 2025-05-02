using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RunnerBuddy.Application.Interfaces;

namespace RunnerBuddy.Application;

public static class ServiceRegistration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));

        List<Type> mapperList = new();

        var mapperServices = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface && t
                .GetInterfaces().ToList()
                .Exists(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapper<,>)));

        mapperList.AddRange(mapperServices);

        foreach (var mapperService in mapperList)
        {
            services.AddSingleton(mapperService);
        }
    }
}

