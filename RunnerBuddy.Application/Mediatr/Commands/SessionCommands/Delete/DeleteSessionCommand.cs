using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Delete;

public class DeleteSessionCommand : IRequest<TaskResponse>
{
    public SessionDto? Session { get; set; }
}