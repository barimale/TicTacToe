using SyslogLogging;
using TicTacToeGame._4x4;
using TicTacToeGame.UIServices.Contract;
using TicTacToeGame.Utilities;

namespace TicTacToeGame.Factory
{
    public partial class Form2 : Form
    {
        private readonly ITicTacToe4x4Manager manager;
        private readonly LoggingModule log;

        public Form2(ITicTacToe4x4Manager manager)
        {
            log = new LoggingModule("tictactoegame-4x4-logs.txt");
            log.Settings.FileLogging = FileLoggingMode.SingleLogFile;

            log.Info("App is initializing.");

            InitializeComponent();
            this.manager = manager;
            this.manager.OnTurn += Manager_OnTurn;

            UIHelper.HideLabels(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
                button16);

            UIHelper.ClearButtons(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
                button16);

            log.Info("App initialized.");
        }

        private void Manager_OnTurn(object? sender, OnTurnArgs e)
        {
            if (e.Column == 0 && e.Row == 0)
            {
                UIHelper.ClearButtons(button1);
            }
            if (e.Column == 1 && e.Row == 0)
            {
                UIHelper.ClearButtons(button2);
            }
            if (e.Column == 2 && e.Row == 0)
            {
                UIHelper.ClearButtons(button3);
            }
            if (e.Column == 3 && e.Row == 0)
            {
                UIHelper.ClearButtons(button4);
            }

            if (e.Column == 0 && e.Row == 1)
            {
                UIHelper.ClearButtons(button5);
            }
            if (e.Column == 1 && e.Row == 1)
            {
                UIHelper.ClearButtons(button6);
            }
            if (e.Column == 2 && e.Row == 1)
            {
                UIHelper.ClearButtons(button7);
            }
            if (e.Column == 3 && e.Row == 1)
            {
                UIHelper.ClearButtons(button8);
            }

            if (e.Column == 0 && e.Row == 2)
            {
                UIHelper.ClearButtons(button9);
            }
            if (e.Column == 1 && e.Row == 2)
            {
                UIHelper.ClearButtons(button10);
            }
            if (e.Column == 2 && e.Row == 2)
            {
                UIHelper.ClearButtons(button11);
            }
            if (e.Column == 3 && e.Row == 2)
            {
                UIHelper.ClearButtons(button12);
            }

            if (e.Column == 0 && e.Row == 3)
            {
                UIHelper.ClearButtons(button13);
            }
            if (e.Column == 1 && e.Row == 3)
            {
                UIHelper.ClearButtons(button14);
            }
            if (e.Column == 2 && e.Row == 3)
            {
                UIHelper.ClearButtons(button15);
            }
            if (e.Column == 3 && e.Row == 3)
            {
                UIHelper.ClearButtons(button16);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Tic Tac Toe 4x4";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();
        }

        private void RefreshGame(object sender, EventArgs e)
        {
            log.Info("App is refreshing.");

            manager.RestartInstance();

            UIHelper.ClearButtons(
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
                button16);

            UIHelper.UnfocusAllButtons(this);

            log.Info("App refreshed.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button1, 0, 0);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
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
                log.Critical(ex.Message);
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
                log.Critical(ex.Message);
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
                manager.buttonClickExecute(button4, 0, 3);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
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
                manager.buttonClickExecute(button5, 1, 0);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
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
                manager.buttonClickExecute(button6, 1, 1);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button10, 2, 1);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
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
                manager.buttonClickExecute(button9, 2, 0);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
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
                manager.buttonClickExecute(button7, 1, 2);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
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
                manager.buttonClickExecute(button8, 1, 3);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button11, 2, 2);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button12, 2, 3);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button13, 3, 0);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button14, 3, 1);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button15, 3, 2);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                manager.buttonClickExecute(button16, 3, 3);
            }
            catch (Exception ex)
            {
                log.Critical(ex.Message);
            }
            finally
            {
                var result = manager.IsFinished();
                if (result)
                    RefreshGame(null, null);
            }
        }
    }
}
