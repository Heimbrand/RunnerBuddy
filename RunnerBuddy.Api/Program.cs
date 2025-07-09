using Microsoft.EntityFrameworkCore;
using RunnerBuddy.Api.EndpointRegistration;
using RunnerBuddy.Api.ExceptionHandler;
using RunnerBuddy.Application;
using RunnerBuddy.Persistance;
using RunnerBuddy.Persistance.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
logger.Information(@"
  _____                             _               _     _       
 |  __ \                           | |             | |   | |      
 | |__) |   _ _ __  _ __   ___ _ __| |__  _   _  __| | __| |_   _ 
 |  _  / | | | '_ \| '_ \ / _ \ '__| '_ \| | | |/ _` |/ _` | | | |
 | | \ \ |_| | | | | | | |  __/ |  | |_) | |_| | (_| | (_| | |_| |
 |_|  \_\__,_|_| |_|_| |_|\___|_|  |_.__/ \__,_|\__,_|\__,_|\__, |
                                                             __/ |
                                                            |___/ 

Vevar igång maskineriet!
(>'-')>  <('-'<)  ^(' - ')^  <('-'<)  (>'-')>

RunnerBuddy är igång! Lycka till med passen! 
");


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
builder.Services.AddOpenApi(); // Todo: Registrera genom ServiceRegistration med options konfig
builder.Services.AddEndpoints(typeof(Program).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication(); 
builder.Services.AddPersistance(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  
}
app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "RunnerBuddy"));

app.MapOpenApi().AllowAnonymous();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();


