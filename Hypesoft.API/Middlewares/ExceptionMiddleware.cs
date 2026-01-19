using System.Net;
using FluentValidation;

namespace Hypesoft.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            await context.Response.WriteAsJsonAsync(new
            {
                errors = ex.Errors.Select(e => e.ErrorMessage)
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(new
            {
                error = ex.Message,
                stackTrace = ex.StackTrace
            });
        }
    }
}
