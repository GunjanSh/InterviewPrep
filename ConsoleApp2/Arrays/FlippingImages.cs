using System;

namespace ConsoleApp2.Arrays
{
    internal class FlippingImages
    {
        // https://leetcode.com/problems/flipping-an-image/description/

        public static void Solve()
        {
            int[][] image = new int[][]
            {
                new int[] {1, 1, 0 },
                new int[] {1, 0, 1 },
                new int[] {0, 0, 0 },
            };

            /*
             *  0 1 1
             *  1 0 1
             *  0 0 0
             */

            int rows = image.Length;
            int cols = image[0].Length;
            int[][] output = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] colArr = new int[cols];

                colArr = image[row];
                Console.WriteLine(image[row]);

                Array.Reverse(colArr);

                for (int col = 0; col < colArr.Length; col++)
                {
                    output[row][col] = (colArr[col] == 1 ? 0 : 1);
                }
            }
        }
    }
}
