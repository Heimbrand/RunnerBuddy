using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Delete;

public class DeleteRunnerCommand : IRequest<TaskResponse>
{
    public RunnerDto? Runner { get; set; }
}

