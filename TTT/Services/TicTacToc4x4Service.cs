
using System.Data.Common;
using TicTacToeGame.Services.Contract;
using TicTacToeGame.Services.TTT4x4;

namespace TicTacToeGame.Services
{
    public class TicTacToc4x4Service : ITicTacToc4x4Service
    {
        private TicTacToe4x4Instance ttt;
        public WinnerOption? result;

        public event EventHandler<OnTurnArgs> OnTurn;


        public WinnerOption? Result => result;

        public TicTacToc4x4Service()
        {
            RestartInstance();
        }

        public BoardStateOptions[][] BoardState => ttt.BoardState;

        public void RestartInstance()
        {
            ttt = new TicTacToe4x4Instance();
            ttt.OnTurn += Ttt_OnTurn;
            result = null;
        }

        private void Ttt_OnTurn(object? sender, OnTurnArgs e)
        {
            if (OnTurn != null)
            {
                OnTurn.Invoke(sender, e);
            }
        }

        public bool IsFinished()
        {
            return ttt.Finished && result != null;
        }

        public void MakeOperation(int row, int column)
        {
            result = ttt.MakeOperation(row, column);
        }

        public void ClearOperation(int row, int column)
        {
            ttt.ClearOperation(row, column);
        }
    }
}
