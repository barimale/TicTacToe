using TicTacToeGame.Services.CorrectedLibs;

namespace TicTacToeGame.Services
{
    internal class TicTacTocService
    {
        private TicTacToeInstance ttt;
        public WinnerOption? result;

        public TicTacTocService()
        {
            RestartInstance();
        }

        public BoardStateOptions[][] BoardState => ttt.BoardState;

        public void RestartInstance()
        {
            ttt = new TicTacToeInstance();
            result = null;
        }

        public bool IsFinished()
        {
            return ttt.Finished && result != null;
        }

        public void MakeOperation(int row, int column)
        {
            result = ttt.MakeOperation(row, column);
        }
    }
}
