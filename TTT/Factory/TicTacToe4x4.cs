using SyslogLogging;
using TicTacToeGame.Services.Contract;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Tic Tac Toe 4x4";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();
        }

        private void rESTARTToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
