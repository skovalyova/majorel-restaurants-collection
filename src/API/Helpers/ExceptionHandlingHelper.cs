using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace Majorel.RestaurantsCollection.API.Helpers
{
    public static class ExceptionHandlingHelper
    {
        private const string InternalServerErrorType = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
        private const string ValidationErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        private const string NotFoundErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.4";

        public static ProblemDetails GetProblemDetails(int statusCode, string message)
        {
            var (Type, Title) = statusCode switch
            {
                StatusCodes.Status400BadRequest => (Type: ValidationErrorType, Title: "Request is malformed."),

                StatusCodes.Status404NotFound => (Type: NotFoundErrorType, Title: "The specified resource was not found."),

                _ => (Type: InternalServerErrorType, Title: "An error occurred while processing your request.")
            };

            var result = new ProblemDetails()
            {
                Type = Type,
                Status = statusCode,
                Title = Title,
                Detail = message
            };

            return result;
        }

        public static string GetErrorMessageFromModelState(ModelStateDictionary modelState)
        {
            var errorMessage = new StringBuilder();

            foreach (var keyModelStatePair in modelState)
            {
                var key = string.IsNullOrEmpty(keyModelStatePair.Key) ? "form" : keyModelStatePair.Key;

                keyModelStatePair.Value.Errors
                    .ToList()
                    .ForEach(error => errorMessage.AppendLine($"{key} : {error.ErrorMessage}"));
            }

            return errorMessage.ToString();
        }
    }
}
