using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Queries.SessionQueries;

internal sealed class GetAllSessionsHandler(ISessionRepository repo, MapSession mapper) : IRequestHandler<GetAllSessionsQuery, List<SessionDto>>
{
    public async Task<List<SessionDto>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
    {
        var sessions = await repo.GetAll();

        if (sessions == null || !sessions.Any())
        {
            throw new Exception("No sessions found.");
        }
        return sessions.Select(s => mapper.MapToDto(s)).ToList();
    }
}