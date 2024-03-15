using TicTacToeGame._3x3.Model;

namespace TicTacToeGame.Forms.Services.Contract
{
    public interface ITicTacTocService
    {
        BoardStateOptions[][] BoardState { get; }
        public WinnerOption? Result { get; }

        bool IsFinished();
        void MakeOperation(int row, int column);
        void RestartInstance();
    }
}