using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class _22NQueens
    {
        public static void NQueens()
        {
            int n = 4;
            //Problem: For a n*n chessboard, place the queens such that no 2 queens can attack each other.
            //Queens can attack in 8 directions. Place the queens such that only 1 queen is in a row, only 1 queen is in col and only 1 queen is diagonally placed.

            List<List<string>> board = new List<List<string>>();
            List<List<List<string>>> output = new List<List<List<string>>>();

            for (int i = 0; i < n; i++)
            {
                board.Add(Enumerable.Repeat(".", n).ToList());
                //board[i] = Enumerable.Repeat(".", n).ToList();    // Gives index out of bounds exception
            }

            int[] leftRow = new int[n];
            int[] lowerDiag = new int[2 * n - 1];
            int[] upperDiag = new int[2 * n - 1];

            PlaceNQueens(0, board, leftRow, lowerDiag, upperDiag, output);
        }


        // Since we are starting from 0,0 row, col... just check left row, upper diagonal, lower diagonal.
        // Left row maintain an array with row number and mark it as 1 if a Queen is placed else 0. Initially all values are 0.
        // Lower diagonal, if you add row+col, it is same across lower diagonal.
        // Upper diagonal, if you add (n-1) + (col-row), it is same across upper diagonal.
        static void PlaceNQueens(int col, List<List<string>> board, int[] leftRow, int[] lowerDiag, int[] upperDiag, List<List<List<string>>> output)
        {
            if (col == board.Count)
            {
                output.Add(new List<List<string>>(board));
                return;
            }

            for (int row = 0; row < board.Count; row++)
            {
                if (board[row][col] == "." 
                    && leftRow[row] == 0
                    && lowerDiag[row+col] == 0
                    && upperDiag[board.Count-1 +  (col-row)] == 0)
                {
                    board[row][col] = "Q";
                    leftRow[row] = 1;
                    lowerDiag[row + col] = 1;
                    upperDiag[board.Count - 1 + (col - row)] = 1;

                    PlaceNQueens(col + 1, board, leftRow, lowerDiag, upperDiag, output);

                    board[row][col] = ".";
                    leftRow[row] = 0;
                    lowerDiag[row + col] = 0;
                    upperDiag[board.Count - 1 + (col - row)] = 0;
                }
            }

        }
    }
}
