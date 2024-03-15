using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicTacToeGame.Factory;
using TicTacToeGame.Forms.Factory;
using TicTacToeGame.Forms.Services;
using TicTacToeGame.Forms.Services.Contract;
using TicTacToeGame.Forms.UIServices;
using TicTacToeGame.Forms.UIServices.Contract;
using WinFormsApp1;

namespace TicTacToeGame.SysTray
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            var formFactory = new FormFactory(ServiceProvider);
            ApplicationConfiguration.Initialize();

            using (MenuSysTray pi = new MenuSysTray(formFactory))
            {
                pi.Display();
                Application.Run();
            }
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ITicTacTocService, TicTacTocService>();
                    services.AddTransient<ITicTacToeManager, TicTacToeManager>();
                    services.AddTransient<ITicTacToe4x4Manager, TicTacToe4x4Manager>();
                    services.AddTransient<ITicTacToc4x4Service, TicTacToc4x4Service>();

                    services.AddTransient<Form1>();
                    services.AddTransient<Form2>();
                });
        }
    }
}