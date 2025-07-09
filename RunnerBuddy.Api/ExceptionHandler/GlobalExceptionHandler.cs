using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RunnerBuddy.Api.ExceptionHandler
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            logger.LogError(exception, "Exception uppstod!: {Message}", exception.Message);


            var details = CreateResponseDetails(exception);

            var clientResponse = new ProblemDetails

            {
                Title = "Exception",
                Status = details.StatusCode,
                Detail = details.Message,
                Instance = httpContext.Request.Path

            };

            httpContext.Response.StatusCode = (int)details.StatusCode!;
            httpContext.Response.ContentType = "application/problem+json";

            await httpContext.Response.WriteAsJsonAsync(clientResponse, cancellationToken);

            return true;

        }
        internal static ErrorDetails CreateResponseDetails(Exception ex)
        {
            var statusCode = ex switch // Kan bygga på denna switchen utifrån vilka exceptions man vill kunna använda sig av.

            {
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                ArgumentException or InvalidOperationException => HttpStatusCode.BadRequest,
                HttpRequestException or KeyNotFoundException => HttpStatusCode.NotFound,
                Exception => HttpStatusCode.InternalServerError,
            };

            var message = ex.Message ?? "Oväntat fel har inträffat";

            return new ErrorDetails

            {

                Message = message,

                StatusCode = (int)statusCode

            };

        }
        internal class ErrorDetails
        {
            public string? Message { get; set; }
            public int? StatusCode { get; set; }
        }
    }
}
