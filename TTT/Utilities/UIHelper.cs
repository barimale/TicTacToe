namespace TicTacToeGame.Utilities
{
    internal static class UIHelper
    {
        public static void HideLabels(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.Text = string.Empty;
                button.TabStop = false;
            }
        }

        public static void ClearButtons(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.BackColor = Color.White;
                button.Enabled = true;
                button.TabStop = false;
            }
        }
    }
}
