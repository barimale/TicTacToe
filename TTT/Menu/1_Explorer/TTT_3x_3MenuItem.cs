using TicTacToeGame;
using TicTacToeGame.Factory;

namespace SystemTrayApp.Menu._2_About
{
    /// <summary>
    /// 
    /// </summary>
    public class TTT_3x_3MenuItem
    {
        private readonly IFormFactory formFactory;

        public TTT_3x_3MenuItem(IFormFactory formFactory)
        {
            this.formFactory = formFactory;
        }
        /// <summary>
        /// Is displayed?
        /// </summary>
        bool isLoaded = false;

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns>ContextMenuStrip</returns>
		public ToolStripMenuItem Create()
		{
			// Add the default menu options.
			ToolStripMenuItem item;

			// About.
			item = new ToolStripMenuItem();
			item.Text = "TicTacToe 3x3";
			item.Click += new EventHandler(About_Click);
			item.Image = Resources.About;

			return item;
		}

		/// <summary>
		/// Handles the Click event of the About control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		public void About_Click(object sender, EventArgs e)
		{
			if (!isLoaded)
			{
                isLoaded = true;
                formFactory.CreateTTTForm().Show(); // formfactory here
                isLoaded = false;
			}
		}
	}
}