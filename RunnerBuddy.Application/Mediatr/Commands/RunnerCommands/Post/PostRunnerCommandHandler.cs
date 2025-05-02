using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;

namespace RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Post;

internal sealed class PostRunnerCommandHandler(IRunnerRepository repo, MapRunner mapper) : IRequestHandler<PostRunnerCommand, TaskResponse>
{
    public async Task<TaskResponse> Handle(PostRunnerCommand request, CancellationToken cancellationToken)
    {
        var runner = mapper.MapToEntity(request.Runner);

        if (runner != null)
        {
            await repo.Add(runner);
            return new TaskResponse
            {
                Success = true,
                Message = "Runner added successfully",
            };
        }
        throw new Exception("Could not add Runner");
    }
}