using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;

namespace RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Update;

internal class UpdateSessionCommandHandler(ISessionRepository repo, MapSession mapper) : IRequestHandler<UpdateSessionCommand, TaskResponse>
{
    public async Task<TaskResponse> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
    {
        var session = mapper.MapToEntity(request.Session);

        if (session != null)
        {
            await repo.Update(session);
            return new TaskResponse
            {
                Success = true,
                Message = "Session updated successfully",
            };
        }

        throw new Exception("Failed to update Session");
    }
}

    
