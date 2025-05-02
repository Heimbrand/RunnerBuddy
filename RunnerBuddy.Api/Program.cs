using Microsoft.EntityFrameworkCore;
using RunnerBuddy.Api.ExceptionHandler;
using RunnerBuddy.Application;
using RunnerBuddy.Persistance;
using RunnerBuddy.Persistance.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configs = new ConfigurationBuilder()  
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var connectionString = configs.GetConnectionString("RunnerBuddyConnection") ?? throw new InvalidOperationException("ConnectionString hittades ej");
builder.Services.AddDbContext<RunnerBuddyDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Host.UseSerilog((context, configs) => 
    configs.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); 
builder.Services.AddProblemDetails(); 
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication(); 
builder.Services.AddPersistance(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "RunnerBuddy")); 
    app.MapOpenApi().AllowAnonymous();
}

app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseHttpsRedirection();

// TODO: Registrera endpoints dynamiskt med reflektions

app.Run();


