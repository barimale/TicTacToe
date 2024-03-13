using SystemTrayApp.Menu._2_About;
using TicTacToeGame.Factory;

namespace SystemTrayApp
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextMenu
	{
        private readonly IFormFactory formFactory;

        private readonly TTT_3x_3MenuItem explorer;
		private readonly TTT_4x_4MenuItem about;
        private readonly ExitMenuItem exit;
        private readonly SeparatorMenuItem separator;

        private ContextMenu()
        {
            exit = new ExitMenuItem();
            separator = new SeparatorMenuItem();
        }

        public ContextMenu(IFormFactory formFactory): this()
        {
            this.formFactory = formFactory;
            explorer = new TTT_3x_3MenuItem(this.formFactory);
            about = new TTT_4x_4MenuItem(this.formFactory);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ContextMenuStrip Create()
		{
			// Add the default menu options.
			ContextMenuStrip menu = new ContextMenuStrip();

			menu.Items.Add(explorer.Create());
            menu.Items.Add(about.Create());
			menu.Items.Add(separator.Create());
			menu.Items.Add(exit.Create());

			return menu;
		}
	}
}