using TicTacToeGame.Factory;
using TicTacToeGame.SysTray;

namespace SystemTrayApp.Menu._2_About
{
    /// <summary>
    /// 
    /// </summary>
    public class TTT_4x_4MenuItem
	{
        private readonly IFormFactory formFactory;

        public TTT_4x_4MenuItem(IFormFactory formFactory)
        {
            this.formFactory = formFactory;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ToolStripMenuItem</returns>
        public ToolStripMenuItem Create()
		{
			// Add the default menu options.
			ToolStripMenuItem item;

			// About.
			item = new ToolStripMenuItem();
			item.Text = "TicTacToe 4x4";
			item.Click += new EventHandler(_4x_4_Click);
			item.Image = Resources._4x41;

			return item;
		}

		/// <summary>
		/// Handles the Click event of the 4x4 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		public void _4x_4_Click(object sender, EventArgs e)
		{
            formFactory.CreateTTT4x4Form().Show();
        }
    }
}