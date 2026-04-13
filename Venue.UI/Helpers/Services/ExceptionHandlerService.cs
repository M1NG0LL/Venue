using System.Text;
using Venue.Application.Common;
using Venue.Application.Helpers;
using App = System.Windows.Forms.Application;

namespace Venue.UI
{
    public static class ExceptionHandlerService
    {
        public static void Application_ThreadException(object? sender, ThreadExceptionEventArgs e)
        {
            var response = ExceptionHandler.Handle(e.Exception, "UI Thread");
            ShowErrorPopup(response);
        }

        public static void CurrentDomain_UnhandledException(object? sender, UnhandledExceptionEventArgs e)
        {
            var response = ExceptionHandler.Handle(e.ExceptionObject as Exception, "Background Thread");
            ShowErrorPopup(response);
        }

        public static void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            var response = ExceptionHandler.Handle(e.Exception.InnerException, "Async Task");
            ShowErrorPopup(response);
        }

        public static void ShowErrorPopup(ResponseBase response)
        {
            if (response.IsSuccess) return;

            var message = new StringBuilder();
            message.AppendLine(response.Message);

            if (response.Errors is { Count: > 0 })
            {
                message.AppendLine();
                message.AppendLine("Details:");
                response.Errors.ForEach(e => message.AppendLine($"  • {e}"));
            }

            var result = MessageBox.Show(
                message.ToString(),
                "Unexpected Error",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.No)
                App.Exit();
        }
    }
}
