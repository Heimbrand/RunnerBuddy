using MediatR;
using RunnerBuddy.Api.EndpointRegistration;
using RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Delete;
using RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Post;
using RunnerBuddy.Application.Mediatr.Commands.RunnerCommands.Update;
using RunnerBuddy.Application.Mediatr.Queries.RunnerQueries;
using RunnerBuddy.Domain.Dtos;

namespace RunnerBuddy.Api.Extensions;

internal class RunnerRepositoryEndpointExtension : IEndpoint
{
    private readonly ILogger<RunnerRepositoryEndpointExtension> logger;
    public RunnerRepositoryEndpointExtension(ILogger<RunnerRepositoryEndpointExtension> logger)
    {
        this.logger = logger;
    }

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/runners").WithTags("Runners");
        group.MapGet("", GetAllRunners);
        group.MapGet("{id}", GetRunnerById);
        group.MapPost("", CreateRunner);
        group.MapPut("", UpdateRunner);
        group.MapDelete("", DeleteRunner);
    }

    internal async Task<IResult> GetAllRunners(IMediator mediator)
    {
        try
        {
            var result = await mediator.Send(new GetAllRunnersQuery());
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while getting all runners");
            return Results.BadRequest(e);
        }
    }
    internal async Task<IResult> GetRunnerById(IMediator mediator, int id)
    {
        try
        {
            var result = await mediator.Send(new GetByIdRunnersQuery(id));
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while getting runner by id");
            return Results.BadRequest(e);
        }
    }
    internal async Task<IResult> CreateRunner(IMediator mediator,PostRunnerCommand command)
    {
        try
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while creating runner");
            return Results.BadRequest(e);
        }
    }
    internal async Task<IResult> UpdateRunner(IMediator mediator, UpdateRunnerCommand command)
    {
        try
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while updating runner");
            return Results.BadRequest(e);
        }
    }
    internal async Task<IResult> DeleteRunner(IMediator mediator, DeleteRunnerCommand command)
    {
        try
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while deleting runner");
            return Results.BadRequest(e);
        }
    }
}