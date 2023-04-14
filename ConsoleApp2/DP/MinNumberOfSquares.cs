using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    /// <summary>
    /// Given an integer A. Return minimum count of numbers, sum of whose squares is equal to A.
    /// </summary>
    internal class MinNumberOfSquares
    {
        public static void Solve()
        {
            int sum = 6;
            int num = countMinSquares(sum);
            Console.WriteLine("Minimum number of squares required for sum {0} is {1}", sum, num);

            sum = 4;
            num = countMinSquares(sum);
            Console.WriteLine("Minimum number of squares required for sum {0} is {1}", sum, num);

            sum = 5;
            num = countMinSquares(sum);
            Console.WriteLine("Minimum number of squares required for sum {0} is {1}", sum, num);

            sum = 13;
            num = countMinSquares(sum);
            Console.WriteLine("Minimum number of squares required for sum {0} is {1}", sum, num);
        }
        private static int countMinSquares(int N)
        {
            // https://www.techiedelight.com/minimum-number-of-squares-that-sum-to-given-number/

            // create an auxiliary array dp[], where dp[i] stores the minimum number of squares that sum to `i`
            int[] dp = new int[N + 1];

            // fill the auxiliary array dp[] in a bottom-up manner
            for (int i = 0; i <= N; i++)
            {
                // initialize dp[i] with the maximum number of squares possible
                dp[i] = i;

                // loop through all positive integers less than or equal to the square root of `i`
                // either check j <= sqrt(i) or j*j <=i
                //start from 1, as we need non zero squares
                for (int j = 1; j*j <= i; j++)
                {
                    // calculate the value of dp[i] using the result of a smaller subproblem dp[i-j*j]
                    dp[i] = Math.Min(dp[i], 1 + dp[i - j * j]);
                }
            }

            return dp[N];
        }
    }
}
