using MediatR;
using RunnerBuddy.Domain.Dtos;
using RunnerBuddy.Domain.Entities;

namespace RunnerBuddy.Application.Mediatr.Queries.RunnerQueries;

public class GetByIdRunnersQuery(int id) : IRequest<RunnerDto>
{
    public int Id { get; set; } = id;
}

    
