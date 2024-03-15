﻿namespace TicTacToeGame.Forms.UIServices.Contract
{
    public interface ITicTacToeManager
    {
        void buttonClickExecute(Button button, int row, int column);
        bool IsFinished();
        void RestartInstance();
    }
}