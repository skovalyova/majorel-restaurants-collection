using Microsoft.AspNetCore.Mvc;

namespace Majorel.RestaurantsCollection.API.Helpers
{
    public static class ExceptionHandlingHelper
    {
        private const string InternalServerErrorType = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
        private const string ValidationErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        private const string NotFoundErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.4";

        public static ProblemDetails GetProblemDetails(int statusCode, string message)
        {
            var (type, title) = statusCode switch
            {
                StatusCodes.Status400BadRequest => (Type: ValidationErrorType, Title: "Request is malformed."),

                StatusCodes.Status404NotFound => (Type: NotFoundErrorType, Title: "The specified resource was not found."),

                _ => (Type: InternalServerErrorType, Title: "An error occurred while processing your request.")
            };

            var result = new ProblemDetails()
            {
                Type = type,
                Status = statusCode,
                Title = title,
                Detail = message
            };

            return result;
        }
    }
}
