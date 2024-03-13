using TicTacToeGame;
using TicTacToeGame.Factory;

namespace SystemTrayApp
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
            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();
		}

		/// <summary>
		/// Displays the icon in the system tray.
		/// </summary>
		public void Display()
		{
			// Put the icon in the system tray and allow it react to mouse clicks.			
			ni.Icon = Resources.SystemTrayApp;
			ni.Text = "System Tray Utility Application Demonstration Program";
			ni.Visible = true;

			// Attach a context menu.
			ni.ContextMenuStrip = new ContextMenu(this.formFactory).Create();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		public void Dispose()
		{
			// When the application closes, this will remove the icon from the system tray immediately.
			ni.Dispose();
		}
	}
}