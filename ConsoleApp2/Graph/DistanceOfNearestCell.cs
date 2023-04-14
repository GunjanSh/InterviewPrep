using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Graph
{
    internal class DistanceOfNearestCell
    {
        public static void Solve()
        {
            List<List<int>> matrix = new List<List<int>>
              {
                  new List<int> { 1, 1, 0, 1, 1, 0 },
                  new List<int> { 1, 1, 1, 0, 0, 0 }
              };

            var output = solve(matrix);

            //ouput
            //    [0, 0, 1, 0, 0, 1]
            //    [0, 0, 0, 1, 1, 2]
        }

        public static List<List<int>> solve(List<List<int>> matrix)
        {
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            List<List<int>> minDistanceMatrix = new List<List<int>>();
            int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
            // int[][] directions = {new int[] {0 , 1} , new int[] {1 , 0} , new int[] {-1 , 0} , new int[] {0 , -1}};
            // for(int row = 0; row < matrix.Count; row++)
            // {
            //     minDistanceMatrix.Add(Enumerable.Repeat(int.MaxValue, matrix[0].Count).ToList());
            // }

            for (int row = 0; row < matrix.Count; row++)
            {
                minDistanceMatrix.Add(Enumerable.Repeat(0, matrix[0].Count).ToList());
                for (int col = 0; col < matrix[0].Count; col++)
                {
                    if (matrix[row][col] == 1)
                    {
                        queue.Enqueue((row, col));
                    }
                    else
                    {
                        minDistanceMatrix[row][col] = int.MaxValue;
                    }
                }
            }

            while (queue.Count > 0)
            {
                (int row, int col) top = queue.Dequeue();

                for (int index = 0; index < directions.Length; index++)
                {
                    int newRow = top.row + directions[index][0];
                    int newCol = top.col + directions[index][1];

                    if (newRow >= 0 && newRow < matrix.Count &&
                        newCol >= 0 && newCol < matrix[0].Count)
                    {
                        if (minDistanceMatrix[newRow][newCol] > minDistanceMatrix[top.row][top.col])
                        {
                            minDistanceMatrix[newRow][newCol] = minDistanceMatrix[top.row][top.col] + 1;
                            queue.Enqueue((newRow, newCol));
                        }
                        // else
                        // {
                        //     queue.Enqueue((newRow, newCol));
                        // }
                    }
                }
            }

            return minDistanceMatrix;
        }
    }
}
