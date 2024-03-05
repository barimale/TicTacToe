using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Utilities;

namespace TicTacToeGame.Services
{
    internal class TicTacToeManager
    {
        private TicTacTocService ttt;

        public TicTacToeManager()
        {
            ttt = new TicTacTocService();
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsFinished()
        {
            if (ttt.IsFinished())
            {
                var resultString = string.Empty;
                // show message
                switch (ttt.result)
                {
                    case WinnerOption.Tie:
                        resultString = " padl remis";
                        break;
                    case WinnerOption.XPlayer:
                        resultString = " wygral gracz niebieski";
                        break;
                    case WinnerOption.OPlayer:
                        resultString = " wygral gracz czerwony";
                        break;
                }

                string message = "Koniec:" + resultString + ".";
                string caption = "Wynik";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                MessageBox.Show(message, caption, buttons);
            }

            return ttt.IsFinished();
        }
    }
}
