using TicTacToeGame._4x4.Model;

namespace TicTacToeGame._4x4.Contract
{
    public interface ITicTacToe4x4Instance
    {
        BoardStateOptions[][] BoardState { get; }
        bool Finished { get; }

        event EventHandler<OnTurnArgs> OnTurn;

        void ClearOperation(int row, int column);
        WinnerOption? MakeOperation(int row, int column);
    }
}