using Majorel.RestaurantsCollection.API.Helpers;
using Majorel.RestaurantsCollection.Domain.Exceptions;
using System.Text.Json;

namespace Majorel.RestaurantsCollection.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (NotFoundException exception)
            {
                await HandleExceptionAsync(context, exception, StatusCodes.Status404NotFound);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
        {
            var result = ExceptionHandlingHelper.GetProblemDetails(statusCode, exception.Message);
            var jsonResult = JsonSerializer.Serialize(result);

            _logger.LogError(exception, "{ErrorMessage}", exception.Message);

            context.Response.StatusCode = result.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(jsonResult);
        }
    }
}
