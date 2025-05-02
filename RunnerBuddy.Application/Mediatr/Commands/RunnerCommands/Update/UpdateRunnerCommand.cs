using MediatR;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Update;

public class UpdateRunnerCommand : IRequest<TaskResponse>
{
 public RunnerDto? Runner { get; set; }
}

    
