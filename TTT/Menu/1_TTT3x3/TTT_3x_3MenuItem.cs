using TicTacToeGame.Factory;
using TicTacToeGame.SysTray;

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
			item.Click += new EventHandler(_3x_3_Click);
			item.Image = Resources._3x3;

			return item;
		}

		/// <summary>
		/// Handles the Click event of the About control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		public void _3x_3_Click(object sender, EventArgs e)
		{
            formFactory.CreateTTTForm().Show(); // formfactory here
        }
    }
}