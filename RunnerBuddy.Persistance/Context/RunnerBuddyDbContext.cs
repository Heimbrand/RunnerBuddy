using Microsoft.EntityFrameworkCore;
using RunnerBuddy.Domain.Entities;

namespace RunnerBuddy.Persistance.Context;

public class RunnerBuddyDbContext : DbContext
{
    public DbSet<Runner> Runners { get; set; } 
    public DbSet<Session> Sessions { get; set; }

    public RunnerBuddyDbContext(DbContextOptions<RunnerBuddyDbContext> options) : base(options)
    {
    }
}