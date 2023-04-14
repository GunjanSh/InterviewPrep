using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    /*
        Problem Description
        You are given a set of coins A. In how many ways can you make sum B assuming you have infinite amount of each coin in the set.

        NOTE:

        Coins in set A will be unique. Expected space complexity of this problem is O(B).
        The answer can overflow. So, return the answer % (106 + 7).


        Problem Constraints
        1 <= A <= 500
        1 <= A[i] <= 1000
        1 <= B <= 50000

        Return an integer denoting the number of ways.
     */
    internal class CoinsSumInfinite
    {
        public static void Solve()
        {
            int[] coins = new int[] { 1, 2, 3 };
            int sum = 4; //Ans: 4

            int ways = WaysToGetSum(coins, sum);
            Console.WriteLine("Number of ways to get sum {0} is {1}", sum, ways);

            coins = new int[] { 18, 24, 23, 10, 16, 19, 2, 9, 5, 12, 17, 3, 28, 29, 4, 13, 15, 8 };
            sum = 458; //Ans: 867621

            ways = WaysToGetSum(coins, sum);
            Console.WriteLine("Number of ways to get sum {0} is {1}", sum, ways);
        }

        private static int WaysToGetSum(int[] coins, int sum)
        {
            int[] dp = new int[sum+1];
            dp[0] = 1;

            for (int i = 1; i < sum; i++)
            {
                dp[i] = 0;
            }

            for (int i = 0; i < coins.Length; i++)
            {
                for (int t = 1; t <= sum; t++)
                {
                    if (coins[i] <= t)
                    {
                        dp[t] += (dp[t-coins[i]] % 1000007); 
                    }
                }
            }

            return dp[sum] % 1000007;
        }
    }
}
