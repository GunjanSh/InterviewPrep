using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Graph
{
    internal class NumberOfIslands
    {
        /*
         *  Problem Description
            Given a matrix of integers A of size N x M consisting of 0 and 1. A group of connected 1's forms an island. From a cell (i, j) such that A[i][j] = 1 you can visit any cell that shares a corner with (i, j) and value in that cell is 1.

            More formally, from any cell (i, j) if A[i][j] = 1 you can visit:

            (i-1, j) if (i-1, j) is inside the matrix and A[i-1][j] = 1.
            (i, j-1) if (i, j-1) is inside the matrix and A[i][j-1] = 1.
            (i+1, j) if (i+1, j) is inside the matrix and A[i+1][j] = 1.
            (i, j+1) if (i, j+1) is inside the matrix and A[i][j+1] = 1.
            (i-1, j-1) if (i-1, j-1) is inside the matrix and A[i-1][j-1] = 1.
            (i+1, j+1) if (i+1, j+1) is inside the matrix and A[i+1][j+1] = 1.
            (i-1, j+1) if (i-1, j+1) is inside the matrix and A[i-1][j+1] = 1.
            (i+1, j-1) if (i+1, j-1) is inside the matrix and A[i+1][j-1] = 1.
            Return the number of islands.

            NOTE: Rows are numbered from top to bottom and columns are numbered from left to right.

            Problem Constraints
            1 <= N, M <= 100
            0 <= A[i] <= 1

            Input Format
            The only argument given is the integer matrix A.

            Output Format
            Return the number of islands.
         */

        public static void Solve()
        {
            List<List<int>> matrix = new List<List<int>>
            {
                new List<int> {0, 1, 0},
                new List<int> {0, 0, 1},
                new List<int> {1, 0, 0 } ,
            };

            int count = FindNumberOfIslands(matrix);
            Console.WriteLine("Number of islands is : {0}", count);

            matrix = new List<List<int>>
            {
               new List<int> { 1, 1, 0, 0, 0},
               new List<int> { 0, 1, 0, 0, 0},
               new List<int> { 1, 0, 0, 1, 1},
               new List<int> { 0, 0, 0, 0, 0},
               new List<int> { 1, 0, 1, 0, 1 },
            };

            count = FindNumberOfIslands(matrix);
            Console.WriteLine("Number of islands is : {0}", count);
        }

        static int FindNumberOfIslands(List<List<int>> matrix)
        {
            int rowCount = matrix.Count;
            int colCount = matrix[0].Count;

            bool[,] visited = new bool[rowCount, colCount];
            //int[] rowIndices = new int[8] { 0, 1, 1, 1, -1, -1, -1, 0 }; //This wont work, as you need to give corresponding x and y indices
            //int[] colIndices = new int[8] { 0, 0, 1, 1, 1, -1, -1, -1};
            //8 pairs are - For (x,y) --> 8 directions are --> (x+1,y), (x-1,y), (x,y+1), (x, y-1), (x-1, y-1), (x-1, y+1), (x+1, y+1), (x+1, y-1)
            int[] rowIndices = new int[8] { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] colIndices = new int[8] { 0, 1, 1, 1, 0, -1, -1, -1 };
            int count = 0;

            for (int row=0; row < rowCount; row++)
            {
                for(int col = 0; col < colCount; col++)
                {
                    if(matrix[row][col] == 1 && !visited[row, col])
                    {
                        count++;
                        Dfs(row, col, matrix, visited, rowIndices, colIndices);
                    }
                }
            }

            return count;
        }

        static void Dfs(int row, int col, List<List<int>> matrix, bool[, ] visited, int[] rowIndices, int[] colIndices)
        {
            visited[row, col] = true;

            for(int k = 0; k < 8; k++)
            {
                int rowIdx = row + rowIndices[k];
                int colIdx = col + colIndices[k];

                if(rowIdx >= 0 && rowIdx < matrix.Count && colIdx >= 0 && colIdx < matrix[0].Count
                    && matrix[rowIdx][colIdx] == 1 && !visited[rowIdx, colIdx])
                {
                    Dfs(rowIdx, colIdx, matrix, visited, rowIndices, colIndices);
                }
            }
        }
    }
}
