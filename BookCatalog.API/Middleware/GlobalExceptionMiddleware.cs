using System.Text.Json;
using Microsoft.AspNetCore;
namespace BookCatalog.Middleware;

public class GlobalExceptionMiddleware
{

    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        int statusCode;

        switch (ex)
        {
            case KeyNotFoundException _:
                statusCode = 404;
                break;
            case ArgumentOutOfRangeException _:
                statusCode = 400;
                break;
            case ArgumentException _:
                statusCode = 400;
                break;
            case NullReferenceException _:
                statusCode = 404;
                break;
            default:
                statusCode = 400;
                break;
        }
        context.Response.ContentType = "aplication/json";
        context.Response.StatusCode = statusCode;

        var body = JsonSerializer.Serialize(new
        {
            status = statusCode,
            message = ex.Message
        });
    }
}