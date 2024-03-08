
namespace TicTacToeGame.Services
{
    public interface ITicTacToeManager
    {
        void buttonClickExecute(Button button, int row, int column);
        bool IsFinished();
        void RestartInstance();
    }
}