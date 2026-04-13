using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Venue.Application.Common;
using Venue.Application.Helpers;
using Venue.Infrastructure;
using Venue.Infrastructure.DbContext;
using App = System.Windows.Forms.Application;

namespace Venue.UI
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            App.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            App.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            ConfigureServices(services, configuration);
            Services = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            App.Run(Services.GetRequiredService<Form1>());
        }

        #region Private Methods
        #region Exception Handler
        private static void Application_ThreadException(object? sender, ThreadExceptionEventArgs e)
        {
            var response = ExceptionHandler.Handle(e.Exception, "UI Thread");
            ShowErrorPopup(response);
        }

        private static void CurrentDomain_UnhandledException(object? sender, UnhandledExceptionEventArgs e)
        {
            var response = ExceptionHandler.Handle(e.ExceptionObject as Exception, "Background Thread");
            ShowErrorPopup(response);
        }

        private static void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            var response = ExceptionHandler.Handle(e.Exception.InnerException, "Async Task");
            ShowErrorPopup(response);
        }

        private static void ShowErrorPopup(ResponseBase response)
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
        #endregion

        #region Db Connection
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Default"),
                    x => x.UseNetTopologySuite()
                );
            });

            services.AddInfrastructureScopes(configuration);

            services.AddTransient<Form1>();
        }
        #endregion
        #endregion
    }
}