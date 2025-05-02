using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Domain.Dtos;
using RunnerBuddy.Domain.Entities;

namespace RunnerBuddy.Application.Mappings;

public class MapSession : IMapper<Session, SessionDto>
{
    public SessionDto MapToDto(Session entity)
    {
        return new SessionDto
        {
            Id = entity.Id,
            Date = entity.Date,
            Distance = entity.Distance,
            Location = entity.Location,
            Notes = entity.Notes,
            RunnerId = entity.RunnerId
        };
    }
    public Session MapToEntity(SessionDto dto)
    {
        return new Session
        {
            Id = dto.Id,
            Date = dto.Date,
            Distance = dto.Distance,
            Location = dto.Location,
            Notes = dto.Notes,
            RunnerId = dto.RunnerId
        };
    }
}