using TicTacToeGame.Services.Contract;
using TicTacToeGame.Services.TTT4x4;

namespace TicTacToeGame.Services
{
    public class TicTacToe4x4Manager : ITicTacToe4x4Manager
    {
        private readonly ITicTacToc4x4Service ttt;
        public event EventHandler<OnTurnArgs> OnTurn;

        private Queue<Move> XTurns = new Queue<Move>();
        private Queue<Move> OTurns = new Queue<Move> ();

        public TicTacToe4x4Manager(ITicTacToc4x4Service ttt)
        {
            this.ttt = ttt;
            this.ttt.OnTurn += Ttt_OnTurn;
        }

        private void Ttt_OnTurn(object? sender, OnTurnArgs e)
        {
            if(e.XTurn)
            {
                XTurns.Enqueue(new Move()
                {
                    Row = e.Row,
                    Column = e.Column,
                    XTurn = e.XTurn
                });

                if(XTurns.Count == 5)
                {
                    if (OnTurn != null)
                    {
                        var removed = XTurns.Dequeue();
                        ttt.ClearOperation(removed.Row, removed.Column);
                        OnTurn.Invoke(sender, new OnTurnArgs()
                        {
                            Row = removed.Row,
                            Column = removed.Column,
                            XTurn = removed.XTurn
                        });
                    }
                }
            }
            else
            {
                OTurns.Enqueue(new Move()
                {
                    Row = e.Row,
                    Column = e.Column,
                    XTurn = e.XTurn
                });

                if (OTurns.Count == 5)
                {
                    if (OnTurn != null)
                    {
                        var removed = OTurns.Dequeue();
                        ttt.ClearOperation(removed.Row, removed.Column);
                        OnTurn.Invoke(sender, new OnTurnArgs()
                        {
                            Row = removed.Row,
                            Column = removed.Column,
                            XTurn = removed.XTurn
                        });
                    }
                }
            }
        }

        public void RestartInstance()
        {
            ttt.RestartInstance();
            XTurns.Clear();
            OTurns.Clear();
        }

        public void buttonClickExecute(Button button, int row, int column)
        {
            try
            {
                ttt.MakeOperation(row, column);

                switch (ttt.BoardState[row][column])
                {
                    case BoardStateOptions.X:
                        button.BackColor = Color.Blue;
                        break;
                    case BoardStateOptions.O:
                        button.BackColor = Color.Red;
                        break;
                    case BoardStateOptions.Undefined:
                        button.BackColor = Color.White;
                        break;
                }

                button.Enabled = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsFinished()
        {
            if (ttt.IsFinished())
            {
                string message = GenerateResultString();
                string caption = "Wynik";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                MessageBox.Show(message, caption, buttons);
            }

            return ttt.IsFinished();
        }

        private string GenerateResultString()
        {
            var resultString = string.Empty;
            // show message
            switch (ttt.Result)
            {
                case WinnerOption.Tie:
                    resultString = "Padł remis.";
                    break;
                case WinnerOption.XPlayer:
                    resultString = "Wygrał gracz niebieski.";
                    break;
                case WinnerOption.OPlayer:
                    resultString = "Wygrał gracz czerwony.";
                    break;
            }

            return resultString;
        }
    }
}
