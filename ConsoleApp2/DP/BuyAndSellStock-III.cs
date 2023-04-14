using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class BuyAndSellStock_III
    {
        //Two transactions.
        public static void Solve()
        {
            int[] stocks = new int[] { 1, 2, 1, 2 };  // Ans: 2

            int profit = MaxProfitRec(0, 1, 2, stocks);

            stocks = new int[] { 7, 2, 4, 8, 7 }; // Ans: 6

            profit = MaxProfitRec(0, 1, 2, stocks);

            int[,,] dp = new int[stocks.Length, 2, 3];

            profit = MaxProfitRecMemoize(0, 1, 2, stocks, dp);

            profit = BottomUp(stocks);
        }

        static int MaxProfitRec(int index, int canBuy, int transaction, int[] stocks)
        {
            if (index == stocks.Length || transaction == 0)
            {
                return 0;
            }

            if (canBuy == 1)
            {
                return Math.Max(-stocks[index] + MaxProfitRec(index + 1, 0, transaction, stocks), 0 + MaxProfitRec(index + 1, 1, transaction, stocks));
            }
            else
            {
                return Math.Max(stocks[index] + MaxProfitRec(index + 1, 1, transaction - 1, stocks), 0 + MaxProfitRec(index + 1, 0, transaction, stocks));
            }
        }

        static int MaxProfitRecMemoize(int index, int canBuy, int transaction, int[] stocks, int[,,] dp)
        {
            if (index == stocks.Length || transaction == 0)
            {
                dp[index, canBuy, transaction] = 0;
            }

            if (dp[index, canBuy, transaction] != 0)
            {
                return dp[index, canBuy, transaction];
            }

            if (canBuy == 1)
            {
                return dp[index, canBuy, transaction] = Math.Max(-stocks[index] + MaxProfitRec(index + 1, 0, transaction, stocks), 0 + MaxProfitRec(index + 1, 1, transaction, stocks));
            }
            else
            {
                return dp[index, canBuy, transaction] = Math.Max(stocks[index] + MaxProfitRec(index + 1, 1, transaction - 1, stocks), 0 + MaxProfitRec(index + 1, 0, transaction, stocks));
            }
        }

        static int BottomUp(int[] stocks)
        {
            int[,,] dp = new int[stocks.Length + 1, 2, 3];

            for (int index = stocks.Length-1; index >= 0; index--)
            {
                for (int canBuy = 0; canBuy <= 1; canBuy++)
                {
                    for(int transaction = 1; transaction <= 2; transaction++)
                    {
                        if (canBuy == 1)
                        {
                            dp[index, canBuy, transaction] = Math.Max(-stocks[index] + dp[index + 1, 0, transaction], dp[index + 1, 1, transaction]);
                        }
                        else
                        {
                            dp[index, canBuy, transaction] = Math.Max(stocks[index] + dp[index + 1, 1, transaction - 1], dp[index + 1, 0, transaction]);
                        }
                    }
                }
            }

            return dp[0, 1, 2];
        }
    }
}
