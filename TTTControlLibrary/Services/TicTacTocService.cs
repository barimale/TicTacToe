﻿using TicTacToeGame._3x3;
using TicTacToeGame._3x3.Model;
using TicTacToeGame.Forms.Services.Contract;

namespace TicTacToeGame.Forms.Services
{
    public class TicTacTocService : ITicTacTocService
    {
        private TicTacToeInstance ttt;
        public WinnerOption? result;

        public WinnerOption? Result => result;

        public TicTacTocService()
        {
            RestartInstance();
        }

        public BoardStateOptions[][] BoardState => ttt.BoardState;

        public void RestartInstance()
        {
            ttt = new TicTacToeInstance();
            result = null;
        }

        public bool IsFinished()
        {
            return ttt.Finished && result != null;
        }

        public void MakeOperation(int row, int column)
        {
            result = ttt.MakeOperation(row, column);
        }
    }
}
