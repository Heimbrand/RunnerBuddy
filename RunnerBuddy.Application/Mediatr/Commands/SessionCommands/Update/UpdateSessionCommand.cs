using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Update;

public class UpdateSessionCommand : IRequest<TaskResponse>
{
    public SessionDto? Session { get; set; }
}