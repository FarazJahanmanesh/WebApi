using Domain.Common;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Application.Api.Middleware;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            httpContext.Request.EnableBuffering();
            using StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8);
            string requestBody = await reader.ReadToEndAsync();

            httpContext.Request.Body.Position = 0;
            if (!string.IsNullOrEmpty(httpContext.Request.QueryString.ToString()))
                requestBody += httpContext.Request.QueryString;


            if (ex.InnerException != null)
            {
                // we should to log error here 
            }

            var errorResponse = new ActionResponse()
            {
                Status = 500,
                State = ResponseStateEnum.FAILED,
                Message = "خطایی رخ داده است"
            };

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(errorResponse.ToJson());
        }
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}

