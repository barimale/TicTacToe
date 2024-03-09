using TicTacToeGame.Services.TTT4x4;

namespace TicTacToeGame.Services.Contract
{
    internal interface ITicTacToe4x4Instance
    {
        public event EventHandler<OnTurnArgs> OnTurn;
        BoardStateOptions[][] BoardState { get; }
        bool Finished { get; }

        WinnerOption? MakeOperation(int row, int column);
    }
}