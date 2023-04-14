using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class MatrixChainMultiplication
    {
        /*
             Problem Description
            Given an array of integers A representing chain of 2-D matices such that the dimensions of ith matrix is A[i-1] x A[i].
            Find the most efficient way to multiply these matrices together. The problem is not actually to perform the multiplications, but merely to decide in which order to perform the multiplications.

            Return the minimum number of multiplications needed to multiply the chain. Return an integer denoting the minimum number of multiplications needed to multiply the chain.

            Problem Constraints
            1 <= length of the array <= 1000
            1 <= A[i] <= 100
        */

        public static void Solve()
        {
            int[] dimensions = new int[] { 40, 20, 30, 10, 30 }; // 26000
            int minCost = MatrixMultiply(dimensions);
            Console.WriteLine("Min cost to multiply {0} matrices is {1}", dimensions.Length, minCost);

            dimensions = new int[] { 10, 20, 30 }; // 6000
            minCost = MatrixMultiply(dimensions);
            Console.WriteLine("Min cost to multiply {0} matrices is {1}", dimensions.Length, minCost);
        }

        private static int MatrixMultiply(int[] dimensions)
        {
            int arrLength = dimensions.Length;

            //arrLength as we are considering indices starting from 0.
            int[,] dp = new int[arrLength, arrLength];

            // Set diagonal elements as 0.
            for (int i = 0; i < arrLength; i++)
            {
                dp[i, i] = 0;
            }

            //consider diagonals starting with length 2 then 3 etc.
            for (int len = 2; len <= arrLength-1; len++)
            {
                // start from 1, as dp[0] can be ignored.
                for (int i = 1; i <= arrLength-len; i++)
                {
                    //[i....j] = len; j-i+1 = len; j = len+i-1;
                    int j = len + i - 1;//end index

                    // initialize to max value, as we are looking for min cost of matrix multiplication.
                    dp[i, j] = int.MaxValue;

                    // Partition matrices from 1 to n-1 or j as it is the range of [i .... j].
                    for (int k = i; k < j; k++)
                    {
                        //minCost(1,6) with partition at k=4
                        //minCost(1, 6) = minCost(1,4) + minCost(4+1, 6) + (rows of 1 * cols of 4 * cols of 6);
                        int cost = dp[i, k] + dp[k + 1, j] + (dimensions[i - 1] * dimensions[k] * dimensions[j]);
                        dp[i, j] = Math.Min(dp[i, j], cost);
                    }
                }
            }

            //Ignore 0th row and 0th col, has all 0's.
            //Since we are computing diagonal, 1st row last column is the answer state.
            return dp[1, arrLength - 1];
        }
    }
}
