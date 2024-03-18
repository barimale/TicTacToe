using TicTacToeGame.Factory;
using WinFormsApp1;

namespace TicTacToeGame.Forms.Factory
{
    public interface IFormFactory
    {
        Form2 CreateTTT4x4Form();
        Form1 CreateTTTForm();
    }
}