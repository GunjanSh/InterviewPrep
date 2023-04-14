using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class MinSumPathInMatrix
    {
        public static void FindMinPathInMatrix()
        {
            var matrix = new List<List<int>>()
            {
                new List<int> { 1, 3, 2 },
                new List<int> { 5, 6, 1 },
                new List<int> { 4, 3, 1 },
            };

            int minPathVal = MinPathSum(matrix);
            Console.WriteLine(minPathVal);

            matrix = new List<List<int>>()
            {
                new List<int> { 1, -3, 2 },
                new List<int> { 2, 5, 10 },
                new List<int> {5, -5, 1 },
            };

            minPathVal = MinPathSum(matrix);
            Console.WriteLine(minPathVal);
        }

        private static int MinPathSum(List<List<int>> matrix)
        {
            List<List<int>> dp = new List<List<int>>(matrix.Count);
            int rowCount = matrix.Count;
            int colCount = matrix[0].Count;

            for (int i = 0; i < rowCount; i++)
            {
                dp.Add(Enumerable.Repeat(0, matrix[0].Count).ToList());
            }

            dp[0][0] = matrix[0][0];

            for (int col = 1; col < colCount; col++)
            {
                dp[0][col] = matrix[0][col] + dp[0][col-1]; 
            }

            for (int row = 1; row < rowCount; row++)
            {
                dp[row][0] = matrix[row][0] + dp[row-1][0];
            }

            for(int row = 1; row < rowCount; row++)
            {
                for(int col = 1; col < colCount; col++)
                {
                    dp[row][col] = matrix[row][col] + Math.Min(dp[row - 1][col], dp[row][col - 1]);
                }
            }

            return dp[rowCount-1][colCount-1];
        }
    }
}
