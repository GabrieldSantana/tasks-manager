using TasksManager.API.Contracts;

namespace TasksManager.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            await HandleException(context, ex);
        }
    }

    private static async Task HandleException(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        ErrorResponse response = new();
        
        switch(exception)
        {
            case ArgumentException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                response.StatusCode = 400;
                response.Message = exception.Message;

                break;


            case KeyNotFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                response.StatusCode = 404;
                response.Message = exception.Message;

                break;


            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                response.StatusCode = 500;
                response.Message = exception.Message;

                break;
        }

        await context.Response.WriteAsJsonAsync(response);
    }
}
