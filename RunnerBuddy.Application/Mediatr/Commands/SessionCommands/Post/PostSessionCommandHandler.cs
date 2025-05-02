using MediatR;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Application.Mappings;

namespace RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Post;

public class PostSessionCommandHandler(ISessionRepository repo, MapSession mapper) : IRequestHandler<PostSessionCommand, TaskResponse>
{
    public async Task<TaskResponse> Handle(PostSessionCommand request, CancellationToken cancellationToken)
    {
        var session = mapper.MapToEntity(request.Session);

        if (session != null)
        {
            await repo.Add(session);

            return new TaskResponse() { Message = "Session created successfully", Success = true };
        }

        throw new Exception("Failed to create Session");
    }
}


