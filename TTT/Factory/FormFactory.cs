using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1;

namespace TicTacToeGame.Factory
{
    public interface IFormFactory
    {
        Form1 CreateTTTForm();
        Form2 CreateTTT4x4Form();
    }

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
