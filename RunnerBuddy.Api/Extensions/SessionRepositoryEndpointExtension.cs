using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using RunnerBuddy.Api.EndpointRegistration;
using RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Delete;
using RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Post;
using RunnerBuddy.Application.Mediatr.Commands.SessionCommands.Update;
using RunnerBuddy.Application.Mediatr.Queries.RunnerQueries;
using RunnerBuddy.Application.Mediatr.Queries.SessionQueries;
namespace RunnerBuddy.Api.Extensions;

internal class SessionRepositoryEndpointExtension : IEndpoint
{
    private readonly ILogger<SessionRepositoryEndpointExtension> logger;
    public SessionRepositoryEndpointExtension(ILogger<SessionRepositoryEndpointExtension> logger)
    {
        this.logger = logger;
    }
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/sessions").WithTags("Sessions");
        group.MapGet("", GetAllSessions);
        group.MapGet("{id}", GetSessionById);
        group.MapPost("", CreateSession);
        group.MapPut("", UpdateSession);
        group.MapDelete("", DeleteSession);
    }
    internal async Task<IResult> GetAllSessions(IMediator mediator)
    {

        var result = await mediator.Send(new GetAllSessionsQuery());
        return Results.Ok(result);

    }
    internal async Task<IResult> GetSessionById(IMediator mediator, int id)
    {

        var result = await mediator.Send(new GetByIdSessionsQuery(id));
        return Results.Ok(result);

    }
    internal async Task<IResult> CreateSession(IMediator mediator, PostSessionCommand command)
    {

        var result = await mediator.Send(command);
        return Results.Ok(result);

    }
    internal async Task<IResult> UpdateSession(IMediator mediator, UpdateSessionCommand command)
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);

    }
    internal async Task<IResult> DeleteSession(IMediator mediator, DeleteSessionCommand command)
    {

        var result = await mediator.Send(command);
        return Results.Ok(result);

    }
}