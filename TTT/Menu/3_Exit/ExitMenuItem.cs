using TicTacToeGame.SysTray;

namespace SystemTrayApp
{
    /// <summary>
    /// 
    /// </summary>
    public class ExitMenuItem
	{
        public ToolStripMenuItem Create()
        {
            var item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            item.Image = Resources.Exit;

            return item;
        }

        /// <summary>
        /// Processes a menu item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void Exit_Click(object sender, EventArgs e)
		{
			// Quit without further ado.
			Application.Exit();
		}
	}
}