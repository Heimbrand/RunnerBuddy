using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Delete;

public class DeleteRunnerCommandHandler(IRunnerRepository repo, MapRunner mapper) : IRequestHandler<DeleteRunnerCommand, TaskResponse>
{
    public async Task<TaskResponse> Handle(DeleteRunnerCommand request, CancellationToken cancellationToken)
    {
        var runner = mapper.MapToEntity(request.Runner);
        if (runner != null)
        {
            await repo.Delete(runner);
            return new TaskResponse
            {
                Success = true,
                Message = "Runner deleted successfully",
            };
        }
        throw new Exception("Could not delete Runner");
    }
}

    
