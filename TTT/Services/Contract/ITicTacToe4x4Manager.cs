namespace TicTacToeGame.Services.Contract
{
    public interface ITicTacToe4x4Manager
    {
        void buttonClickExecute(Button button, int row, int column);
        bool IsFinished();
        void RestartInstance();
    }
}