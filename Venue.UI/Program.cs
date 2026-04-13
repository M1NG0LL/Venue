using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App = System.Windows.Forms.Application;

namespace Venue.UI
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; } = null!;

        [STAThread]
        static async Task Main()
        {
            #region Exception handling
            App.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            App.ThreadException += ExceptionHandlerService.Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandlerService.CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += ExceptionHandlerService.TaskScheduler_UnobservedTaskException;
            #endregion

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            Services = await services.BuilderAsync(configuration);

            ApplicationConfiguration.Initialize();
            App.Run(Services.GetRequiredService<Form1>());
        }
    }
}