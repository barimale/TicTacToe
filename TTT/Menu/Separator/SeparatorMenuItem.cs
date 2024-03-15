namespace TicTacToeGame.SysTray.Menu.Separator
{
    /// <summary>
    /// 
    /// </summary>
    public class SeparatorMenuItem
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ToolStripSeparator Create()
        {
            ToolStripSeparator sep;

            sep = new ToolStripSeparator();

            return sep;
        }
    }
}