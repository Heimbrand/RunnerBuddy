using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Queries.SessionQueries;

internal sealed class GetByIdSessionsHandler(ISessionRepository repo, MapSession mapper) : IRequestHandler<GetByIdSessionsQuery, SessionDto>
{
    public async Task<SessionDto> Handle(GetByIdSessionsQuery request, CancellationToken cancellationToken)
    {
        var entity = await repo.GetById(request.Id);
        if (entity == null)
        {
            throw new Exception($"Session with id {request.Id} not found.");
        }
        var dto = mapper.MapToDto(entity);
        return dto;
    }
}

    
