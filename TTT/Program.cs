using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemTrayApp;
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

            if(args.Length == 0)
            {
                using (MenuSysTray pi = new MenuSysTray(formFactory))
                {
                    pi.Display();
                    Application.Run();
                }

                return;
            }

            ApplicationConfiguration.Initialize();

            switch (args[0])
            {
                case "systray":
                    using (MenuSysTray pi = new MenuSysTray(formFactory))
                    {
                        pi.Display();
                        Application.Run();
                    }
                    break;
                case "3x3":
                    formFactory.CreateTTTForm();
                    break;
                case "4x4":
                    formFactory.CreateTTT4x4Form();
                    break;
            }
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