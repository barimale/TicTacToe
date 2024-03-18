using Microsoft.Extensions.DependencyInjection;
using TicTacToeGame.Factory;
using WinFormsApp1;

namespace TicTacToeGame.Forms.Factory
{
    public class FormFactory : IFormFactory
    {
        private IServiceProvider _serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Form2 CreateTTT4x4Form()
        {
            return _serviceProvider.GetRequiredService<Form2>();
        }

        public Form1 CreateTTTForm()
        {
            return _serviceProvider.GetRequiredService<Form1>();
        }
    }
}
