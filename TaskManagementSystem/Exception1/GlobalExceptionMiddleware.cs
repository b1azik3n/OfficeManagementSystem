using Newtonsoft.Json;
using System.Net;

namespace TaskManagementSystem.Exception1
{
    public class GlobalExceptionMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> logger;
        private readonly RequestDelegate next;

        public GlobalExceptionMiddleware( ILogger<GlobalExceptionMiddleware> logger,RequestDelegate next)
        {
            next = next ?? throw new ArgumentNullException(nameof(next));
            logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.LogInformation("GlobalExceptionMiddleware is constructed");

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.ToString());
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                error = new
                {
                    message = "An error occurred while processing your request.",
                    details = ex.Message
                }
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
