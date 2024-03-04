namespace TicTacToeGame.Services
{
    internal class TicTacTocService
    {
        private TicTacToeInstanceCorrected ttt;
        public WinnerOption? result;

        public TicTacTocService()
        {
            RestartInstance();
        }

        public BoardStateOptions[][] BoardState => ttt.BoardState;

        public void RestartInstance()
        {
            ttt = new TicTacToeInstanceCorrected();
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
