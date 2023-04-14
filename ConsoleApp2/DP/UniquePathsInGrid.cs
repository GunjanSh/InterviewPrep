using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class UniquePathsInGrid
    {
        public static void FindUniquePathsInGrid()
        {
            var matrix = new List<List<int>>()
            {
                new List<int> { 0, 0, 0 },
                new List<int> { 1, 1, 1  },
                new List<int> { 0, 0, 0 },
            };

            int minPathVal = UniquePaths(matrix);
            Console.WriteLine(minPathVal);

            matrix = new List<List<int>>()
            {
                new List<int> { 0, 0, 0 },
                new List<int> { 0, 1, 0  },
                new List<int> { 0, 0, 0 },
            };

            minPathVal = UniquePaths(matrix);
            Console.WriteLine(minPathVal);

            matrix = new List<List<int>>()
            {
                  new List<int> { 1, 0, 1, 0},
                  new List<int> { 1, 1, 0, 1},
                  new List<int> { 1, 1, 1, 1},
                  new List<int> { 0, 0, 0, 0},
                  new List<int> { 0, 1, 1, 1},
                  new List<int> { 0, 0, 1, 1},
                  new List<int> { 1, 0, 0, 1 },
            };

            minPathVal = UniquePaths(matrix);
            Console.WriteLine(minPathVal);
        }

        private static int UniquePaths(List<List<int>> matrix)
        {
            List<List<int>> ways = new List<List<int>>();
            int rowCount = matrix.Count;
            int colCount = matrix[0].Count;

            for (int row = 0; row < rowCount; row++)
            {
                ways.Add(Enumerable.Repeat(0, colCount).ToList());
            }

            for(int col = 0; col < colCount; col++)
            {
                if (matrix[0][col] == 0)
                    ways[0][col] = 1;
                else
                {
                    int idx = col;
                    while (idx < colCount)
                    { 
                        ways[0][idx++] = 0;
                    }

                    break;
                }
            }

            for(int row = 0; row < rowCount; row++)
            {
                if (matrix[row][0] == 0)
                {
                    ways[row][0] = 1;
                }
                else
                {
                    int idx = row;
                    while (idx < rowCount)
                    {
                        ways[idx++][0] = 0;
                    }
                    break;
                }
            }

            for(int row = 1; row < rowCount; row++)
            {
                for (int col = 1; col < colCount; col++)
                {
                    if (matrix[row][col] == 1)
                    {
                        ways[row][col] = 0;
                    }
                    else
                    {
                        ways[row][col] = ways[row - 1][col] + ways[row][col - 1];
                    }
                }
            }        

            return ways[rowCount-1][colCount-1];
        }
    }
}
