using TicTacToeGame.Services.TTT4x4;

namespace TicTacToeGame.Services.Contract
{
    public interface ITicTacToc4x4Service
    {
        public event EventHandler<OnTurnArgs> OnTurn;
        BoardStateOptions[][] BoardState { get; }
        WinnerOption? Result { get; }

        bool IsFinished();
        void MakeOperation(int row, int column);
        void RestartInstance();
    }
}