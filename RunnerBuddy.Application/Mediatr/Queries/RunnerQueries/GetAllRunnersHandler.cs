using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Queries.RunnerQueries;

internal sealed class GetAllRunnersHandler(IRunnerRepository repo, MapRunner mapper) : IRequestHandler<GetAllRunnersQuery, List<RunnerDto>>
{
    public async Task<List<RunnerDto>> Handle(GetAllRunnersQuery request, CancellationToken cancellationToken)
    {
        var runners = await repo.GetAll();

        if (runners == null || !runners.Any())
        {
            throw new Exception("No runners found.");
        }

        return runners.Select(r => mapper.MapToDto(r)).ToList();
    }
}

    
