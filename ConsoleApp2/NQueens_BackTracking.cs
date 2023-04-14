using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class NQueens_BackTracking
    {
        //static HashSet<int> rowSet = new HashSet<int>();
        static HashSet<int> colSet = new HashSet<int>();
        static HashSet<int> leftDiagonalSet = new HashSet<int>();
        static HashSet<int> rightDiagonalSet = new HashSet<int>();
        //static List<List<string>> output = new List<List<string>>();

        internal static void SolveNQueens()
        {
            Solve(5);
            //Solve(1);
        }

        private static void Solve(int N)
        {
            List<List<string>> board = new List<List<string>>(N);
            List<List<string>> output = new List<List<string>>();

            if (N == 1)
            {
                board.Add(new List<string> { "Q" });
                return;
            }
            else if (N > 3)
            {
                for (int i = 0; i < N; i++)
                {
                    board.Add(Enumerable.Repeat(".", N).ToList());
                }

                SolveNQueens(0, N, board, output);
            }
        }

        private static void SolveNQueens(int row, int N, List<List<string>> board, List<List<string>> output)
        {
            if (row == N)
            {
                var currBoard = new List<string>();

                foreach (var list in board)
                {
                    currBoard.Add(string.Join(null, list));
                }

                output.Add(currBoard);

                return;
            }

            for (int col = N-1; col >= 0; col--)
            {
                if (// !rowSet.Contains(row) &&
                    !colSet.Contains(col)
                    && !leftDiagonalSet.Contains(row - col)
                    && !rightDiagonalSet.Contains(row + col))
                {
                    //rowSet.Add(row);
                    colSet.Add(col);
                    leftDiagonalSet.Add(row - col);
                    rightDiagonalSet.Add(row + col);

                    board[row][col] = "Q";

                    SolveNQueens(row + 1, N, board, output);

                    board[row][col] = ".";

                    //rowSet.Remove(row);
                    colSet.Remove(col);
                    leftDiagonalSet.Remove(row - col);
                    rightDiagonalSet.Remove(row + col);
                }
            }
        }
    }
}
