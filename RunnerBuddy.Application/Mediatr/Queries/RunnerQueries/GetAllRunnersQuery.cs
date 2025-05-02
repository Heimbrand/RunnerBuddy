using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Queries.RunnerQueries;

public class GetAllRunnersQuery : IRequest<List<RunnerDto>>
{

}

    
