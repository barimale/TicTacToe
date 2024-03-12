namespace TicTacToeGame._4x4
{
    public class OnTurnArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool XTurn { get; set; }
    }
}
