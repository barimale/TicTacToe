namespace TicTacToeGame._4x4.Model
{
    public class OnTurnArgs : EventArgs
    {
        public Move? Turn { get; set; }
    }
}
