using TicTacToeGame.Services.Contract;
using TicTacToeGame.Services.TTT4x4;
using TicTacToeGame.Utilities;

namespace TicTacToeGame.Services
{
    // WIP map BUtton -> row, column
    public class Move
    {
        // clear
        public Button Button { get; set; }
        // clearOperation
        public int Row { get; set; }
        public int Column { get; set; }
        public bool XTurn { get; set; }
    }

    public class ButtonToBoard
    {
        public Button Button { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class TicTacToe4x4Manager : ITicTacToe4x4Manager
    {
        private readonly ITicTacToc4x4Service ttt;
        private Stack<Move> XTurn = new Stack<Move>();
        private Stack<Move> OTurn = new Stack<Move>();

        //public static ButtonToBoard[] buttonToBoardDefinitions = new ButtonToBoard[16]
        //{

        //};

        public TicTacToe4x4Manager(ITicTacToc4x4Service ttt)
        {
            this.ttt = ttt;
            this.ttt.OnTurn += Ttt_OnTurn;
        }

        // WIP
        private Button GetButton(int row, int column)
        {
            return new Button();
        }

        private void Ttt_OnTurn(object? sender, OnTurnArgs e)
        {
            // queues here WIP
            if (e.XTurn)
            {
                XTurn.Push(new Move()
                {
                    Button = GetButton(e.Row, e.Column),
                    Row = e.Row,
                    Column = e.Column,
                    XTurn = e.XTurn
                });

                if(XTurn.Count == 5)
                {
                    var toBeDeleted = XTurn.Pop();
                    ttt.ClearOperation(toBeDeleted.Row, toBeDeleted.Column);
                    UIHelper.ClearButtons(GetButton(toBeDeleted.Row, toBeDeleted.Column));
                }
            }
            else
            {
                OTurn.Push(new Move()
                {
                    Button = GetButton(e.Row, e.Column),
                    Row = e.Row,
                    Column = e.Column,
                    XTurn = e.XTurn
                });

                if (OTurn.Count == 5)
                {
                    var toBeDeleted = OTurn.Pop();
                    ttt.ClearOperation(toBeDeleted.Row, toBeDeleted.Column);
                    UIHelper.ClearButtons(GetButton(toBeDeleted.Row, toBeDeleted.Column));
                }
            }

        }

        public void RestartInstance()
        {
            ttt.RestartInstance();
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
