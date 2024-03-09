using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicTacToeGame.Factory;
using TicTacToeGame.Services;
using TicTacToeGame.Services.Contract;
using WinFormsApp1;

namespace TicTacToeGame
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
            Application.Run(formFactory.CreateTTT4x4Form()); // use args here
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<ITicTacTocService, TicTacTocService>();
                    services.AddTransient<ITicTacToeManager, TicTacToeManager>();
                    services.AddTransient<ITicTacToe4x4Manager, TicTacToe4x4Manager>();

                    services.AddTransient<IFormFactory, FormFactory>();
                    services.AddTransient<Form1>();
                    services.AddTransient<Form2>();
                });
        }
    }
}