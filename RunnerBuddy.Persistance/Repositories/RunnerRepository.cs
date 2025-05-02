using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Domain.Entities;
using RunnerBuddy.Persistance.Context;

namespace RunnerBuddy.Persistance.Repositories;

public class RunnerRepository(RunnerBuddyDbContext context) : GenericRepository<Runner>(context), IRunnerRepository
{
}