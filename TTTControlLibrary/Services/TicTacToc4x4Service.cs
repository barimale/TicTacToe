using TicTacToeGame._4x4.Contract;
using TicTacToeGame._4x4.Model;
using TicTacToeGame.Forms.Services.Contract;

namespace TicTacToeGame.Forms.Services
{
    public class TicTacToc4x4Service : ITicTacToc4x4Service
    {
        private ITicTacToe4x4Instance ttt;
        public WinnerOption? result;

        public event EventHandler<OnTurnArgs> OnTurn;


        public WinnerOption? Result => result;

        public TicTacToc4x4Service(ITicTacToe4x4Instance ttt)
        {
            this.ttt = ttt;
            RestartInstance();
        }

        public BoardStateOptions[][] BoardState => ttt.BoardState;

        public void RestartInstance()
        {
            this.ttt.CleanInstance();
            this.ttt.OnTurn += Ttt_OnTurn;
            this.result = null;
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
