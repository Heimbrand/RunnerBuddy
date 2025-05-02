using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Queries.SessionQueries;

public class GetAllSessionsQuery : IRequest<List<SessionDto>>
{
    
}