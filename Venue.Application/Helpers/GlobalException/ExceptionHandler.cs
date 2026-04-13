using Microsoft.Extensions.Logging;
using Venue.Application.Common;

namespace Venue.Application.Helpers
{
    public static class ExceptionHandler
    {
        public static ResponseBase Handle(Exception? exception, string source = "Unknown")
        {
            if (exception == null)
                return ResponseBase.Failure("An unknown error occurred.");

            List<string> errors = new List<string>(["Something went Wrong"]);

            if (exception.InnerException != null)
                errors.Add($"Inner Exception: {exception.InnerException.Message}");

            if (exception.StackTrace != null)
                errors.Add($"Source: {source}");

            return ResponseBase.Failure(exception.Message, errors);
        }
    }
}
