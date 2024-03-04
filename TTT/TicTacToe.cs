using TicTacToeGame.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private TicTacTocService ttt;

        public Form1()
        {
            InitializeComponent();
            ttt = new TicTacTocService();

            HideLabels(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9);

            ClearButtons(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9);
        }

        private void HideLabels(params Button[] btns)
        {
            foreach (var btn in btns)
            {
                btn.Text = string.Empty;
            }
        }

        private void ClearButtons(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.BackColor = Color.White;
                button.Enabled = true;
            }
        }

        private void rESTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearButtons(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9);

            ttt.RestartInstance();
        }

        private void buttonClickExecute(Button button, int row, int column)
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

        private void IsFinished()
        {
            if (ttt.IsFinished())
            {
                var resultString = string.Empty;
                // show message
                switch (ttt.result)
                {
                    case WinnerOption.Tie:
                        resultString = " remis";
                        break;
                    case WinnerOption.XPlayer:
                        resultString = " wygral gracz X";
                        break;
                    case WinnerOption.OPlayer:
                        resultString = " wygral gracz O";
                        break;
                }

                string message = "Koniec:" + resultString + ".";
                string caption = "Wynik";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                MessageBox.Show(message, caption, buttons);

                rESTARTToolStripMenuItem_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button1, 0, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button2, 0, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button3, 0, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button4, 1, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button5, 1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button6, 1, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button7, 2, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button8, 2, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                buttonClickExecute(button9, 2, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsFinished();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.Text = "Tic Tac Toe";
        }
    }
}
