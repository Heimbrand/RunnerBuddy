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
            PlannedDistance = entity.PlannedDistance,
            ActualDistance = entity.ActualDistance,
            Location = entity.Location,
            Notes = entity.Notes,
            RunnerId = entity.RunnerId,
            AveragePace = entity.AveragePace,
            IsCompleted = entity.IsCompleted
        };
    }
    public Session MapToEntity(SessionDto dto)
    {
        return new Session
        {
            Id = dto.Id,
            Date = dto.Date,
            PlannedDistance = dto.PlannedDistance,
            ActualDistance = dto.ActualDistance,
            Location = dto.Location,
            Notes = dto.Notes,
            RunnerId = dto.RunnerId,
            AveragePace = dto.AveragePace,
            IsCompleted = dto.IsCompleted
        };
    }
}