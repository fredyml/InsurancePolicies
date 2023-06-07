using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace InsurancePolicies.Infrastructure.Exceptions
{
    public class MongoExceptionHandler : IExceptionHandler
    {
        public IActionResult Handle(Exception exception)
        {
            if (exception is MongoException mongoException)
            {
                var errorMessage = $"A database error occurred: {mongoException.Message}";
                var errorResponse = new ObjectResult(errorMessage)
                {
                    StatusCode = StatusCodes.Status503ServiceUnavailable,
                };

                return errorResponse;
            }

            throw new ArgumentException("The exception type is not supported by this handler.", nameof(exception));
        }
    }
}
