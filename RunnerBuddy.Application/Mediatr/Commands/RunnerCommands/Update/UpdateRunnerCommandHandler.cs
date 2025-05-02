using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;

namespace RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Update;

internal sealed class UpdateRunnerCommandHandler(IRunnerRepository repo, MapRunner mapper) : IRequestHandler<UpdateRunnerCommand, TaskResponse>
{
    public async Task<TaskResponse> Handle(UpdateRunnerCommand request, CancellationToken cancellationToken)
    {
        var runner = mapper.MapToEntity(request.Runner);

        if (runner != null)
        {
            await repo.Update(runner);
            return new TaskResponse
            {
                Success = true,
                Message = "Runner updated successfully",
            };
        }
        throw new Exception("Could not update Runner");
    }
}