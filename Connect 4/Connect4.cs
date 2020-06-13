using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Connect4
    {
        Player currentPlayer;
        Player player1;
        Player player2;
        bool endGame;
        Disc[,] board;
        public Connect4()
        {
            player1 = new Player(1);
            player2 = new Player(2);
            currentPlayer = player1;
            endGame = false;
            board = new Disc[7, 6];
            board.Initialize();
        }

        public string play(int col)
        {
            // without input validation 
            if (endGame) return "Game has finished!";
            if (MoveDisc(col) == false) return "Column full!";
            if (checkWin())
            {
                endGame = true;
                return $"Player {currentPlayer.number} wins!";
            }
            string outStr = $"Player {currentPlayer.number} has a turn";
            currentPlayer = GetNextPlayer(currentPlayer);
            return outStr;
        }

        bool MoveDisc(int column)
        {
            if (board[0, column] != null) return false;
            for (int i = 5; i >= 0; i--)
            {
                if (board[i, column] == null)
                {
                    board[i, column] = new Disc() { owner = currentPlayer };
                    break;
                }
            }
            return true;
        }

        bool checkWin()
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (checkLanes(col, row) || checkDiagonal(col, row)) return true;
                }
            }
            return false;
        }

        bool checkLanes(int offsetX, int offsetY)
        {
            bool cols, rows;
            for (int k = 0; k < 4; k++)
            {
                cols = true;
                rows = true;
                for (int i = 0; i < 4; i++)
                {
                    cols &= board[offsetX + k, offsetY + i] != null
                        && board[offsetX + k, offsetY + i].owner == currentPlayer;

                    rows &= board[offsetX + i, offsetY + k] != null
                        && board[offsetX + i, offsetY + k].owner == currentPlayer;
                }
                if (cols || rows) return true;
            }
            return false;
        }

        bool checkDiagonal(int offsetX, int offsetY)
        {
            bool toright = true;
            bool toleft = true;
            for (int i = 0; i < 4; i++)
            {
                toright &= board[i + offsetX, i + offsetY] != null
                    && board[i + offsetX, i + offsetY].owner == currentPlayer;

                toleft &= board[3 + offsetX - i, i + offsetY] != null
                   && board[3 + offsetX - i, i + offsetY].owner == currentPlayer;

            }
            if (toright || toleft) return true;
            return false;
        }

        Player GetNextPlayer(Player player)
        {
            return player == player1 ? player2 : player1;
        }
    }
}
