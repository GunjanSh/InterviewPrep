using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class BuyAndSellStock___IV
    {
        public static void Solve()
        {
            int[] stocks = new int[] { 1, 2, 1, 2 };  // Ans: 2
            int transactions = 2;

            int profit = BottomUp(stocks, transactions);

            stocks = new int[] { 7, 2, 4, 8, 7 }; // Ans: 6

            profit = BottomUp(stocks, transactions);

            stocks = new int[] { 19230, 13765, 6863, 3840, 8367, 15603, 16327, 15140, 5582, 12937, 9472, 14190, 9541, 4126, 2757, 400, 19685, 15908, 4929, 18136, 16050, 6622, 13439, 265, 5846, 3188, 8756, 4960, 18781, 11139, 5152, 12314 };
            transactions = 100000089;

            if (transactions > stocks.Length)
            {
                int[,] dp = new int[stocks.Length, 2];
                for (int idx = 0; idx < stocks.Length; idx++)
                {
                    dp[idx, 0] = -1;
                    dp[idx, 1] = -1;
                }

                profit = MaxProfitRec(1, 0, stocks, dp);
            }
            else
            {
                profit = BottomUp(stocks, transactions / 2);
            }
        }

        static int BottomUp(int[] stocks, int transactions)
        {
            long[,,] dp = new long[stocks.Length + 1, 2, transactions+1];

            for (int index = stocks.Length - 1; index >= 0; index--)
            {
                for (int canBuy = 0; canBuy <= 1; canBuy++)
                {
                    for (long transaction = 1; transaction <= transactions; transaction++)
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

            return (int)dp[0, 1, transactions];
        }
        static int MaxProfitRec(int canBuy, int index, int[] stocks, int[,] dp)
        {
            if (index == stocks.Length)
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
                profit = Math.Max(-stocks[index] + MaxProfitRec(0, index + 1, stocks, dp), 0 + MaxProfitRec(1, index + 1, stocks, dp));
            }
            else
            {
                //If i can sell today then we have 2 choices
                //Sell --> add currVal + buy as true
                //Dont sell --> canBuy as false
                profit = Math.Max(stocks[index] + MaxProfitRec(1, index + 1, stocks, dp), 0 + MaxProfitRec(0, index + 1, stocks, dp));
            }

            return dp[index, canBuy] = profit;
        }
    }
}
