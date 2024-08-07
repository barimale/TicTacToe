﻿using TicTacToeGame._4x4.Contract;
using TicTacToeGame._4x4.Model;

namespace TicTacToeGame._4x4
{
    public class TicTacToe4x4Instance : ITicTacToe4x4Instance
    {
        public event EventHandler<OnTurnArgs>? OnTurn;
        private bool XTurn { get; set; } = true;
        public bool Finished { get; internal set; } = false;

        public void CleanInstance()
        {
            XTurn = true;
            Finished = false;
            BoardState = new BoardStateOptions[4][]
            {
            new BoardStateOptions[4],
            new BoardStateOptions[4],
            new BoardStateOptions[4],
            new BoardStateOptions[4]
            };
            OnTurn = null;
        }

        public BoardStateOptions[][] BoardState { get; internal set; } = new BoardStateOptions[4][]
        {
        new BoardStateOptions[4],
        new BoardStateOptions[4],
        new BoardStateOptions[4],
        new BoardStateOptions[4]
        };


        private bool AllEqual<T>(params T[] values)
        {
            if (values == null || values.Length == 0)
            {
                return true;
            }

            return values.All((v) => v.Equals(values[0]));
        }

        private bool CheckForWinner(out WinnerOption? WinnerObject)
        {
            WinnerOption? winnerOption = WinnerObject = new WinnerOption?[5]
            {
            CheckCross1(),
            CheckCross2(),
            CheckRows(),
            CheckColumns(),
            CheckOuter2x2s()
            }.FirstOrDefault((po) => po.HasValue);
            Finished = winnerOption.HasValue;
            return winnerOption.HasValue;
        }

        private WinnerOption? CheckCross1()
        {
            int num = 0;
            for (int i = 0; i < BoardState.Length - 1; i++)
            {
                if (BoardState[i][i] == BoardState[i + 1][i + 1])
                {
                    num++;
                }
            }

            if (num >= 3 && BoardState[0][0] != 0)
            {
                return BoardState[0][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            return null;
        }

        private WinnerOption? CheckCross2()
        {
            int num = 0;
            for (int i = 0; i < BoardState.Length - 1; i++)
            {
                if (BoardState[i][BoardState.Length - i - 1] == BoardState[i + 1][BoardState.Length - i - 2])
                {
                    num++;
                }
            }

            if (num >= 3 && BoardState[0][3] != 0)
            {
                return BoardState[0][BoardState.Length - 1] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            return null;
        }

        private WinnerOption? CheckRows()
        {
            if (AllEqual(BoardState[0][0], BoardState[0][1], BoardState[0][2], BoardState[0][3]) && BoardState[0][0] != 0)
            {
                return BoardState[0][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            if (AllEqual(BoardState[1][0], BoardState[1][1], BoardState[1][2], BoardState[1][3]) && BoardState[1][0] != 0)
            {
                return BoardState[1][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            if (AllEqual(BoardState[2][0], BoardState[2][1], BoardState[2][2], BoardState[2][3]) && BoardState[2][0] != 0)
            {
                return BoardState[2][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            if (AllEqual(BoardState[3][0], BoardState[3][1], BoardState[3][2], BoardState[3][3]) && BoardState[3][0] != 0)
            {
                return BoardState[3][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            return null;
        }

        private WinnerOption? CheckOuter2x2s()
        {
            if (AllEqual(BoardState[0][0], BoardState[0][1], BoardState[1][0], BoardState[1][1]) && BoardState[0][0] != 0)
            {
                return BoardState[0][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }
            if (AllEqual(BoardState[0][2], BoardState[0][3], BoardState[1][2], BoardState[1][3]) && BoardState[0][2] != 0)
            {
                return BoardState[0][2] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }
            if (AllEqual(BoardState[2][0], BoardState[2][1], BoardState[3][0], BoardState[3][1]) && BoardState[2][0] != 0)
            {
                return BoardState[2][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }
            if (AllEqual(BoardState[2][2], BoardState[2][3], BoardState[3][2], BoardState[3][3]) && BoardState[2][2] != 0)
            {
                return BoardState[2][2] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }
            return null;
        }

        private WinnerOption? CheckColumns()
        {
            if (AllEqual(BoardState[0][0], BoardState[1][0], BoardState[2][0], BoardState[3][0]) && BoardState[0][0] != 0)
            {
                return BoardState[0][0] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            if (AllEqual(BoardState[0][1], BoardState[1][1], BoardState[2][1], BoardState[3][1]) && BoardState[0][1] != 0)
            {
                return BoardState[0][1] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            if (AllEqual(BoardState[0][2], BoardState[1][2], BoardState[2][2], BoardState[3][2]) && BoardState[0][2] != 0)
            {
                return BoardState[0][2] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            if (AllEqual(BoardState[0][3], BoardState[1][3], BoardState[2][3], BoardState[3][3]) && BoardState[0][3] != 0)
            {
                return BoardState[0][3] != BoardStateOptions.X ? WinnerOption.OPlayer : WinnerOption.XPlayer;
            }

            return null;
        }

        public void ClearOperation(int row, int column)
        {
            if (Finished)
            {
                throw new Exception("Game finished.");
            }

            if (row > 3)
            {
                throw new IndexOutOfRangeException("The maximum row index can be 3");
            }

            if (column > 3)
            {
                throw new IndexOutOfRangeException("The maximum column index can be 3");
            }

            BoardState[row][column] = BoardStateOptions.Undefined;
        }

        public WinnerOption? MakeOperation(int row, int column)
        {
            if (Finished)
            {
                throw new Exception("Game finished.");
            }

            if (row > 3)
            {
                throw new IndexOutOfRangeException("The maximum row index can be 3");
            }

            if (column > 3)
            {
                throw new IndexOutOfRangeException("The maximum column index can be 3");
            }

            if (BoardState[row][column] != 0)
            {
                throw new Exception("This field is not empty.");
            }

            if (OnTurn != null)
            {
                OnTurn.Invoke(null, new OnTurnArgs()
                {
                    Turn = new Move()
                    {
                        Row = row,
                        Column = column,
                        XTurn = XTurn
                    }
                });
            }

            BoardState[row][column] = XTurn ? BoardStateOptions.X : BoardStateOptions.O;
            XTurn = !XTurn;
            if (CheckForWinner(out var WinnerObject))
            {
                return WinnerObject;
            }

            if (BoardState.Where((bs1) => bs1.Where((bs2) => bs2 == BoardStateOptions.Undefined).Count() > 0).Count() == 0)
            {
                Finished = true;
                return WinnerOption.Tie;
            }

            return null;
        }
    }
}
