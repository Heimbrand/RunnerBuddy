using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Persistance.Repositories;

namespace RunnerBuddy.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistance(this IServiceCollection services)
    {
        var repositoryTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface && t
                .GetInterfaces().ToList().Exists(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IGenericRepository<>)));

        var nonGenericRepositories = repositoryTypes.Where(t => t != typeof(GenericRepository<>));

        foreach (Type repoType in nonGenericRepositories)
        {
            List<Type> interfaces;

            if (repoType.BaseType?.IsGenericType ?? false)
            {
                // Om basen är generisk => filtrera alla interfaces och behåll de som inte är generiska
                interfaces = repoType.GetInterfaces().Where(i => !i.IsGenericType).ToList();
            }
            else
            {
                // om basen inte är generisk => ta bort IGenericRepository från listan.
                interfaces = repoType.GetInterfaces().Where(i => i != typeof(IGenericRepository<>)).ToList();
            }

            if (interfaces.Count != 1)
            {
                throw new InvalidOperationException($"Repositoriet: {repoType.Name} Får bara implementera ett interface som implementerar IGenericRepository");
            }

            services.AddScoped(interfaces[0], repoType); // [0] syftar på det interface som repositoriet i den aktuella iterationen implementerar.
        }
    }
}

