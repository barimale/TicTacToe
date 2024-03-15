using TicTacToeGame._4x4.Model;

namespace TicTacToeGame.Forms.UIServices.Contract
{
    public interface ITicTacToe4x4Manager
    {
        public event EventHandler<OnTurnArgs> OnTurn;
        void buttonClickExecute(Button button, int row, int column);
        bool IsFinished();
        void RestartInstance();
    }
}