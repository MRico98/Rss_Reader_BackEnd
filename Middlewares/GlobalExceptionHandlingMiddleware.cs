using System.Net;
using Rss_Reader_BackEnd.Exceptions;

namespace Rss_Reader_BackEnd.Middlewares;

public class GlobalExceptionHandlingMiddleware 
{

    private readonly RequestDelegate _next;
    public GlobalExceptionHandlingMiddleware(RequestDelegate next) => _next = next;
    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        }
        catch (ManualException) {
            context.Response.StatusCode = (int)HttpStatusCode.BadGateway;
        }
    } 
}