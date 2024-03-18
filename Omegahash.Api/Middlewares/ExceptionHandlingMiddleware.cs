using System;
using System.Text.Json;

namespace Omegahash.Api.Middlewares;

using Omegahash.Shared.Exceptions;
using System.Text.Json.Serialization;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);
        var response = new Response
        {
            Title = GetTitle(exception),
            Status = statusCode,
            Detail = exception.Message,
            Errors = GetErrors(exception)
        };
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(text: JsonSerializer.Serialize(response, SourceGenerationContext.Default.Response));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(Exception exception) =>
        exception switch
        {
            ApplicationException applicationException => applicationException.Title,
            _ => "Server Error"
        };

    private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
    {
        IReadOnlyDictionary<string, string[]>? errors = null;
        if (exception is ValidationException validationException)
        {
            errors = validationException.ErrorsDictionary;
        }
        return errors ?? new Dictionary<string, string[]>();
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Response))]
internal partial class SourceGenerationContext : JsonSerializerContext { }

public struct Response
{
    public string Title { get; set; }
    public int Status { get; set; }
    public string Detail { get; set; }
    public IReadOnlyDictionary<string, string[]> Errors { get; set; }
}