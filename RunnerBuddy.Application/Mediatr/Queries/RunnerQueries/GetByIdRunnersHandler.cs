using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Queries.RunnerQueries;

internal sealed class GetByIdRunnersHandler(IRunnerRepository repo, MapRunner mapper) : IRequestHandler<GetByIdRunnersQuery, RunnerDto>
{
    public async Task<RunnerDto> Handle(GetByIdRunnersQuery request, CancellationToken cancellationToken)
    {
        var entity = await repo.GetById(request.Id);

        if (entity == null)
        {
            throw new Exception($"Runner with id {request.Id} not found.");
        }
        var dto = mapper.MapToDto(entity);
        return dto;
    }
}