using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1;

namespace TicTacToeGame.Factory
{
    public interface IFormFactory
    {
        Form1 CreateTTTForm();
    }

    public class FormFactory : IFormFactory
    {
        private IServiceProvider _serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Form1 CreateTTTForm()
        {
            return _serviceProvider.GetRequiredService<Form1>();
        }
    }
}
