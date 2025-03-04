using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RunnerBuddy.Persistance.Interfaces;
using RunnerBuddy.Persistance.Repositories;

namespace RunnerBuddy.Persistance;

public class ServiceRegistration 
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        // Dynamic registering of repositories using reflection
    }
}