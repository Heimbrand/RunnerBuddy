using Microsoft.EntityFrameworkCore;
using RunnerBuddy.Domain.Entities;

namespace RunnerBuddy.Persistance.Context;

public class RunnerDbContext(DbContextOptions<RunnerDbContext> options) : DbContext(options)
{
    public DbSet<Runner> Runners { get; set; } 
    public DbSet<Session> Sessions { get; set; } 
}