using TicTacToeGame.Factory;
using TicTacToeGame.SysTray;

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
            ni = new NotifyIcon();
		}

		/// <summary>
		/// Displays the icon in the system tray.
		/// </summary>
		public void Display()
		{
			ni.Icon = Resources._4x4;
			ni.Text = "System Tray Utility Application Demonstration Program";
			ni.Visible = true;
			ni.ContextMenuStrip = new ContextMenu(this.formFactory).Create();
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