using System.Net;
using FluentValidation;

namespace Hypesoft.API.Middlewares;

/// <summary>
/// Middleware for handling exceptions in the request pipeline.
/// Catches validation and general exceptions, returning appropriate error responses.
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invokes the middleware to handle the request and catch exceptions.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            // Handle validation errors with 422 status
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            await context.Response.WriteAsJsonAsync(new
            {
                errors = ex.Errors.Select(e => e.ErrorMessage)
            });
        }
        catch (Exception ex)
        {
            // Handle general exceptions with 500 status
            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(new
            {
                error = ex.Message,
                stackTrace = ex.StackTrace
            });
        }
    }
}
