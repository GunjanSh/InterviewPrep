using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class BuyAndSellStock___V_Cooldown
    {
        public static void Solve()
        {
            List<int> A = new List<int> { 3, 17, 4, 12, 8, 10, 15, 17, 9, 5, 3, 4, 6, 18, 16 };
            int[,] dp = new int[A.Count+1, 2];

            for (int idx = 0; idx <= A.Count; idx++)
            {
                dp[idx, 0] = -1;
                dp[idx, 1] = -1;
            }

            int profit = MaxProfitRec(1, 0, A.ToArray(), dp);
        }

        static int MaxProfitRec(int canBuy, int index, int[] stocks, int[,] dp)
        {
            if (index == stocks.Length || index > stocks.Length)
            {
                return 0;
            }

            if (dp[index, canBuy] != -1)
            {
                return dp[index, canBuy];
            }

            int profit;

            if (canBuy == 1)
            {
                //curr index then we have 2 choices --> buy (curr profit is -stocks[currIdx] or not buy 
                profit = Math.Max(-stocks[index] + MaxProfitRec(0, index + 1, stocks, dp), MaxProfitRec(1, index + 1, stocks, dp));
            }
            else
            {
                //If i can sell today then we have 2 choices
                //Sell --> Math.Max()
                //Dont sell
                profit = Math.Max(stocks[index] + MaxProfitRec(1, index + 2, stocks, dp), MaxProfitRec(0, index + 1, stocks, dp));
            }

            return dp[index, canBuy] = profit;
        }
    }
}
