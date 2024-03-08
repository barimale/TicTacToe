using TicTacToeGame.Services.CorrectedLib;

namespace TicTacToeGame.Services
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