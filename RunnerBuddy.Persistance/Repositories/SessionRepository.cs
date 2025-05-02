using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Domain.Entities;
using RunnerBuddy.Persistance.Context;

namespace RunnerBuddy.Persistance.Repositories;

public class SessionRepository(RunnerBuddyDbContext context) : GenericRepository<Session>(context), ISessionRepository
{
}