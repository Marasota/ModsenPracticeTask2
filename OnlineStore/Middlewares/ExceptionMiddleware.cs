using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OnlineStore.BLL.Exceptions;
using System.Net;
using System.Text.Json;

namespace OnlineStore.WebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    status = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case ValidationException validationException:
                    status = HttpStatusCode.BadRequest;
                    message = validationException.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Internal Server Error";
                    break;
            }

            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
