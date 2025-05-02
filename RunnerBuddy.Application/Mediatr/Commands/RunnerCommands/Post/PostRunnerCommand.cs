using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Post;

public class PostRunnerCommand : IRequest<TaskResponse>
{
    public RunnerDto? Runner { get; set; }
}