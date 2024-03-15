using SystemTrayApp;
using SystemTrayApp.Menu._2_About;
using TicTacToeGame.Forms.Factory;
using TicTacToeGame.SysTray.Menu.Separator;

namespace TicTacToeGame.SysTray.Menu
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextMenu
    {
        private readonly IFormFactory formFactory;

        private readonly TTT_3x_3MenuItem _3x_3tictactoe;
        private readonly TTT_4x_4MenuItem _4x_4tictactoe;
        private readonly ExitMenuItem exit;
        private readonly SeparatorMenuItem separator;

        private ContextMenu()
        {
            exit = new ExitMenuItem();
            separator = new SeparatorMenuItem();
        }

        public ContextMenu(IFormFactory formFactory) : this()
        {
            this.formFactory = formFactory;
            _3x_3tictactoe = new TTT_3x_3MenuItem(this.formFactory);
            _4x_4tictactoe = new TTT_4x_4MenuItem(this.formFactory);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();

            menu.Items.Add(_3x_3tictactoe.Create());
            menu.Items.Add(_4x_4tictactoe.Create());
            menu.Items.Add(separator.Create());
            menu.Items.Add(exit.Create());

            return menu;
        }
    }
}