using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;

namespace RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Delete;

internal sealed class DeleteSessionCommandHandler(ISessionRepository repo, MapSession mapper) : IRequestHandler<DeleteSessionCommand, TaskResponse>
{
    public async Task<TaskResponse> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
    {
        var session = mapper.MapToEntity(request.Session);

        if (session != null)
        {
            await repo.Delete(session);
            return new TaskResponse
            {
                Success = true,
                Message = "Session deleted successfully."
            };
        }
        throw new Exception("Failed to delete Session");
    }
}