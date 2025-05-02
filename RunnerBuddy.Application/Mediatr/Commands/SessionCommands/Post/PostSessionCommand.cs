using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Post;

public class PostSessionCommand : IRequest<TaskResponse>
{
    public SessionDto? Session { get; set; } 
}

    
