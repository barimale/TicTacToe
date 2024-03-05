using TicTacToeGame.Services;
using TicTacToeGame.Utilities;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private TicTacToeManager manager;

        public Form1()
        {
            InitializeComponent();
            manager = new TicTacToeManager();

            UIHelper.HideLabels(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9);

            UIHelper.ClearButtons(
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



        private void RefreshGame(object sender, EventArgs e)
        {
            UIHelper.ClearButtons(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9);

            manager.RestartInstance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button1, 0, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if(result)
                    RefreshGame(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button2, 0, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button3, 0, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button4, 1, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button5, 1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button6, 1, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button7, 2, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button8, 2, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button9, 2, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.Text = "Tic Tac Toe";
        }
    }
}
