namespace TicTacToeGame.Utilities
{
    internal static class UIHelper
    {
        public static void HideLabels(params Button[] btns)
        {
            foreach (var btn in btns)
            {
                btn.Text = string.Empty;
            }
        }

        public static void ClearButtons(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.BackColor = Color.White;
                button.Enabled = true;
            }
        }
    }
}
