using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Queries.SessionQueries;

public class GetByIdSessionsQuery(int id) : IRequest<SessionDto>
{
    public int Id { get; set; } = id;
}