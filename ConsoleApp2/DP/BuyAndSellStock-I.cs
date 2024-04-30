using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    internal class BuyAndSellStock_I
    {
        /*
         * DP Playlist - https://www.youtube.com/watch?v=FfXoiwwnxFw&list=PLgUwDviBIf0qUlt5H_kiKYaNSqJ81PMMY&index=2 
         * https://www.youtube.com/watch?v=nGJmxkUJQGs&list=PLgUwDviBIf0qUlt5H_kiKYaNSqJ81PMMY&index=38       III
         * https://www.youtube.com/watch?v=IGIe46xw3YY  With Cooldown
         * https://www.youtube.com/watch?v=-uQGzhYj8BQ  III - Atmost 2 transaction
         * https://www.youtube.com/watch?v=nGJmxkUJQGs&list=PLgUwDviBIf0qUlt5H_kiKYaNSqJ81PMMY&index=38 II - Infinite transactions
         * https://www.youtube.com/watch?v=IV1dHbk5CDc  IV - Atmost K transactions
         */

        public static void Solve()
        {
            int[] stocks = new int[] { 1, 4, 5, 2, 4 };   // Ans: 4

            int profit = MaxProfitEasy(stocks);
            Console.WriteLine("Profit earned after selling is {0}", profit);

            stocks = new int[] { 1, 2 };   // Ans: 1

            profit = MaxProfitEasy(stocks);
            Console.WriteLine("Profit earned after selling is {0}", profit);

            stocks = new int[] { 4, 2, 3, 8, 5, 9, 7 };   // Ans: 7

            profit = MaxProfitEasy(stocks);
            Console.WriteLine("Profit earned after selling is {0}", profit);
        }

        private static int MaxProfitEasy(int[] stocks)
        {
            int maxProfit = int.MinValue;
            int minPrice = int.MaxValue;

            for(int i = 0; i < stocks.Length; i++)
            {
                minPrice = Math.Min(minPrice, stocks[i]);
                maxProfit = Math.Max(maxProfit, stocks[i] - minPrice);
            }

            return maxProfit;
        }

        private static int MaxProfit(int[] stocks)
        {
            if (stocks.Length == 0)
            {
                return 0;
            }

            //Take stock at day 0 as minimum stock value.
            int minStockSoFar = stocks[0];
            //Take max profit as 0.
            int maxProfit = 0;

            //You cannot sell on day 0, you can only buy, so start loop from day 1/index 1.
            for (int day = 1; day < stocks.Length; day++)
            {
                //Immediate profit is current day stock value - previous day stock value
                var currProfit = stocks[day] - stocks[day - 1];
                
                //Save min stock value so far.
                minStockSoFar = Math.Min(minStockSoFar, stocks[day]);

                if (currProfit > 0)
                {
                    maxProfit = Math.Max(maxProfit, stocks[day] - minStockSoFar);
                }
            }

            return maxProfit;
        }
    }
}
