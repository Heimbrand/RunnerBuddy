using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Domain.Dtos;
using RunnerBuddy.Domain.Entities;

namespace RunnerBuddy.Application.Mappings;

public class MapRunner : IMapper<Runner, RunnerDto>
{
    public RunnerDto MapToDto(Runner entity)
    {
        var dto = new RunnerDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Age = entity.Age,
            Height = entity.Height,
            Weight = entity.Weight,
        };

        if (entity.Sessions == null) return dto;

        foreach (var session in entity.Sessions)
        {
            var sessionDto = new SessionDto
            {
                Id = session.Id,
                Date = session.Date,
                Distance = session.Distance,
                Location = session.Location,
                Notes = session.Notes,
                RunnerId = session.RunnerId
            };
            dto.Sessions?.Add(sessionDto);
        }
        return dto;
    }
    public Runner MapToEntity(RunnerDto dto)
    {
        var entity = new Runner
        {
            Id = dto.Id,
            Name = dto.Name,
            Age = dto.Age,
            Height = dto.Height,
            Weight = dto.Weight,
        };
        if (dto.Sessions == null) return entity;

        foreach (var session in dto.Sessions)
        {
            var sessionEntity = new Session
            {
                Id = session.Id,
                Date = session.Date,
                Distance = session.Distance,
                Location = session.Location,
                Notes = session.Notes,
                RunnerId = session.RunnerId
            };
            entity.Sessions?.Add(sessionEntity);
        }
        return entity;
    }
}