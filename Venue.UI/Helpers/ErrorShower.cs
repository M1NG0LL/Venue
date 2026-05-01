using Venue.Application.Common;

namespace Venue.UI.Helpers
{
    internal static class ErrorShower
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(ResponseBase responseBase)
        {
            if (responseBase.IsSuccess)
                return;

            var errorMessage = responseBase?.Message ?? "An unknown error occurred.";

            if (responseBase?.Errors != null && responseBase.Errors.Any())
            {
                var errorsList = string.Join(
                    Environment.NewLine,
                    responseBase.Errors.Select((error, index) => $"{index + 1}. {error}")
                );

                errorMessage += Environment.NewLine + Environment.NewLine + errorsList;
            }

            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
