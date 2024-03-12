using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicTacToeGame.Factory;
using TicTacToeGame.Services;
using TicTacToeGame.Services.Contract;
using TicTacToeGame.UIServices;
using TicTacToeGame.UIServices.Contract;
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

            var is4x4Choosen = args.Length > 0 && args[0] == "4x4";

            ApplicationConfiguration.Initialize();
            Application.Run(is4x4Choosen ?
                                formFactory.CreateTTT4x4Form():
                                formFactory.CreateTTTForm()
                                );
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<ITicTacTocService, TicTacTocService>();
                    services.AddTransient<ITicTacToeManager, TicTacToeManager>();
                    services.AddTransient<ITicTacToe4x4Manager, TicTacToe4x4Manager>();
                    services.AddTransient<ITicTacToc4x4Service, TicTacToc4x4Service>();

                    services.AddTransient<IFormFactory, FormFactory>();
                    services.AddTransient<Form1>();
                    services.AddTransient<Form2>();
                });
        }
    }
}