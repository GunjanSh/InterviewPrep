using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Arrays
{
    public class GameOfLife2D
    {
        public static void CallFunc()
        {
            //int[][] board = new int[][]
            //{
            //    new int[] { 1, 1 },
            //    new int[] { 1, 0 },
            //};

            int[][] board = new int[][]
           {
                    new int[] { 0,1,0 },
                    new int[] { 0,0,1 },
                    new int[] { 1,1,1 },
                    new int[] { 0,0,0 },
           };

            var output = GameOfLife(board);
        }

        // WRONG APPROACH
        // You don't need queue, just check neighbors and set the values.
        static int[][] GameOfLife(int[][] board)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            int[,] visited = new int[rows, cols];
            int[][] output = new int[rows][];

            var queue = new Queue<(int row, int col)>();
            int[] rowIndices = new int[] { 1, 1, 1, -1, -1, -1, 0, 0 };
            int[] colIndices = new int[] { 0, 1, -1, 0, 1, -1, 1, -1 };

            // -- 1 with < 2 live will be dead(0)
            // -- 1 with 2 or 3 will remain
            // -- 1 with > 3 will be dead(0)
            // -- 0 with 3 live(1) will be live

            for (int i = 0; i < rows; i++)
            {
                output[i] = new int[cols];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //if (board[i][j] == 1)
                    //{
                    output[i][j] = board[i][j];
                        queue.Enqueue((i, j));
                    //}
                }
            }

            while (queue.Count > 0)
            {
                var front = queue.Dequeue();
                var row = front.row;
                var col = front.col;
                int counter = 0;
                int zeroCounter = 0;

                for (int i = 0; i < 8; i++)
                {
                    var newRow = row + rowIndices[i];
                    var newCol = col + colIndices[i];

                    if (newRow >= 0 && newRow < rows
                    && newCol >= 0 && newCol < cols
                    && visited[newRow, newCol] == 0
                    && board[newRow][newCol] == 1
                    )
                    {
                        counter++;
                        queue.Enqueue((newRow, newCol));
                        visited[newRow, newCol] = 1;
                    }

                    if (newRow >= 0 && newRow < rows
                   && newCol >= 0 && newCol < cols
                   && visited[newRow, newCol] == 0
                   && board[row][col] == 0
                   && board[newRow][newCol] == 1
                   )
                    {
                        zeroCounter++;
                        queue.Enqueue((newRow, newCol));
                        visited[newRow, newCol] = 1;
                    }
                }

                if (board[row][col] == 1 && (counter < 2 || counter > 3))
                {
                    output[row][col] = 0;
                }

                if (board[row][col] == 0 && zeroCounter  == 3)
                {
                    output[row][col] = 1;
                }
            }

            return output;
        }
    }
}
