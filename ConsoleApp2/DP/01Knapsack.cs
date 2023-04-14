using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    /*
    Problem Description
    Given two integer arrays A and B of size N each which represent values and weights associated with N items respectively.
    Also given an integer C which represents knapsack capacity.
    Find out the maximum value subset of A such that sum of the weights of this subset is smaller than or equal to C.
    NOTE: You cannot break an item, either pick the complete item, or don’t pick it (0-1 property).

    Problem Constraints
    1 <= N <= 500
    1 <= C, B[i] <= 106
    1 <= A[i] <= 50

    Input Format
    First argument is an integer array A of size N denoting the values on N items.
    Second argument is an integer array B of size N denoting the weights on N items.
    Third argument is an integer C denoting the knapsack capacity.

    Output Format
    Return a single integer denoting the maximum value subset of A such that sum of the weights of this subset is smaller than or equal to C.
     */
    internal class KS01Knapsack
    {
        public static void Solve()
        {
            List<int> values = new List<int> { 6, 7, 3, 1 };
            List<int> weights = new List<int> { 5, 4, 2, 2 };
            int capacity = 7;        // Ans: 10

            int maxVal = MaxValueOptimizedForScaler(values, weights, capacity);
            Console.WriteLine("Max value of knapsack is {0}", maxVal);

            values = new List<int> { 6, 10, 12 };
            weights = new List<int> { 10, 20, 30 };
            capacity = 50; // Ans: 22

            maxVal = MaxValueOptimizedForScaler(values, weights, capacity);
            Console.WriteLine("Max value of knapsack is {0}", maxVal);
        }

        private static int MaxValueOptimizedForScaler(List<int> valuesList, List<int> weightsList, int capacity)
        {
            int[] values = valuesList.ToArray();
            int[] weights = weightsList.ToArray();

            int[] prev = new int[capacity + 1];
            int[] curr = new int[capacity + 1];
            int length = values.Length;

            for (int len = 1; len <= length; len++)
            //for (int w = 1; w <= capacity; w++)
            {
                for (int w = 1; w <= capacity; w++)
                //for (int len = 1; len <= length; len++)
                {
                    if (weights[len - 1] <= w)
                    {
                        curr[w] = Math.Max(prev[w], values[len - 1] + prev[w - weights[len - 1]]);
                    }
                    else
                    {
                        curr[w] = prev[w];
                    }
                }

                Array.Copy(curr, prev, curr.Length);
            }

            return curr[capacity];
        }

        #region
        //int[] prev = new int[C + 1];
        //int[] curr = new int[C + 1];
        //for (int i = 1; i <= A.length; i++) {
        //    for (int j = 1; j <= C; j++) {
        //        if (j >= B[i - 1]) { // Can pick the weight
        //            curr[j] = Math.max(prev[j - B[i - 1]] + A[i - 1], prev[j]);
        //        } else {
        //            curr[j] = prev[j];
        //        }
        //    }
        //    System.arraycopy(curr, 0, prev, 0, prev.length);
        //}
        #endregion

        private static int MaxValue3(List<int> values, List<int> weights, int capacity)
        {
            int[] prev = new int[capacity + 1];
            int[] curr = new int[capacity + 1];
            for (int i = 1; i <= values.Count; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (j >= weights[i - 1])
                    { // Can pick the weight
                        curr[j] = Math.Max(prev[j - weights[i - 1]] + values[i - 1], prev[j]);
                    }
                    else
                    {
                        curr[j] = prev[j];
                    }
                }
                Array.Copy(curr, prev, prev.Length);
                //System.arraycopy(curr, 0, prev, 0, prev.length);
            }
            return curr[capacity];
        }

        private static int MaxValue2(List<int> values, List<int> weights, int capacity)
        {
            int length = values.Count;
            int[] prev = new int[capacity+1];
            int[] curr = new int[capacity+1];

            for (int len = 1; len <= length; len++)
                //for (int w = 1; w <= capacity; w++)
            {
                for (int w = capacity; w >= 1; w--)
                //for (int w = 1; w <= capacity; w++)
                //for (int len = 1; len <= length; len++)
                {
                    if (weights[len - 1] <= w)
                    {
                        curr[w] = Math.Max(prev[w],  values[len - 1] + prev[w - weights[len - 1]]);
                    }
                    else
                    {
                        curr[w] = prev[w];
                    }
                    prev[w] = curr[w];
                }
                //Array.Copy(curr, prev, curr.Length);
            }

            return curr[capacity]; 
           
        }

        private static int  MaxValue(List<int> values, List<int> weights, int capacity)
        {
            int length = weights.Count;
            int[,] dp = new int[capacity + 1, length + 1];

            for (int i = 0; i <= capacity; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    dp[i, j] = 0;
                }
            }

            for(int w = 1; w <= capacity; w++)
            {
                for (int len = 1; len <= length; len++)
                {
                    dp[w, len] = dp[w, len - 1];
                    if (weights[len-1] <= w)
                    {
                        dp[w, len] = Math.Max(dp[w, len], values[len - 1] + dp[w - weights[len - 1], len - 1]);
                    }
                }
            }

            return dp[capacity, length];
        }
    }
}
