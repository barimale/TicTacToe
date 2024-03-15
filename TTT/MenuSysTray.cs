using TicTacToeGame.Forms.Factory;
using TicTacToeGame.SysTray.Menu;

namespace TicTacToeGame.SysTray
{
    /// <summary>
    /// 
    /// </summary>
    class MenuSysTray : IDisposable
    {
        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        NotifyIcon ni;

        private readonly IFormFactory formFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuSysTray"/> class.
        /// </summary>
        public MenuSysTray(IFormFactory formFactory)
        {
            this.formFactory = formFactory;
            ni = new NotifyIcon();
        }

        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            ni.Icon = Resources._4x4;
            ni.Text = "Tic Tac Toe Launcher";
            ni.Visible = true;
            ni.ContextMenuStrip = new ContextMenu(formFactory).Create();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            ni.Dispose();
        }
    }
}