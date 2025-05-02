using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RunnerBuddy.Persistance.Context;

public class RunnerBuddyDbContextFactory : IDesignTimeDbContextFactory<RunnerBuddyDbContext>
{
    public RunnerBuddyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = configuration.GetConnectionString("RunnerBuddyConnection");

        var optionsBuilder = new DbContextOptionsBuilder<RunnerBuddyDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new RunnerBuddyDbContext(optionsBuilder.Options);
    }
}

