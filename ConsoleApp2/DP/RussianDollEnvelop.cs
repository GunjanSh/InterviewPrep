using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DP
{
    /*
    Problem Description
    Given a matrix of integers A of size N x 2 describing dimensions of N envelopes, where A[i][0] denotes the height of the ith envelope and A[i][1] denotes the width of the ith envelope.
    One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.
    Find the maximum number of envelopes you can put one inside other.

    Problem Constraints
    1 <= N <= 1000
    1 <= A[i][0], A[i][1] <= 109
     */
    internal class RussianDollEnvelop
    {
        public static void Solve()
        {
            List<List<int>> list = new List<List<int>>
            {
                new List<int> {5, 4},
                new List<int> {6, 4},
                new List<int> {6, 7},
                new List<int> { 2, 3},  // Ans: 3
            };

            int maxEnvelops = MaxEnvelops(list);
            Console.WriteLine("Max envelops that can be enclosed with each other is {0}", maxEnvelops);

            list = new List<List<int>>
            {
                new List<int> {8, 9},
                new List<int> {8, 18}, //Ans: 1
            };

            maxEnvelops = MaxEnvelops(list);
            Console.WriteLine("Max envelops that can be enclosed with each other is {0}", maxEnvelops);

            list = new List<List<int>>
            {
                new List<int> {3, 12},
                new List<int> {19, 8 },
                new List<int> {14, 17},
                new List<int> {15, 18},
                new List<int> {18, 15 },
                new List<int> {10, 7 },
                new List<int> {20, 20},
                new List<int> {14, 1},
                new List<int> {19, 15},
                new List<int> {5, 6},      // Ans: 5
            };

            maxEnvelops = MaxEnvelops(list);
            Console.WriteLine("Max envelops that can be enclosed with each other is {0}", maxEnvelops);

            list = new List<List<int>>
            {
                  new List<int> {335, 885},
                  new List<int> {678, 736},
                  new List<int> {72, 86},
                  new List<int> {448, 80},
                  new List<int> {919, 863},
                  new List<int> {830, 287},
                  new List<int> {252, 564},
                  new List<int> {386, 985},
                  new List<int> {717, 256},
                  new List<int> {231, 412},
                  new List<int> {910, 222},
                  new List<int> {649, 253},
                  new List<int> {871, 455},
                  new List<int> {135, 256},
                  new List<int> {743, 514},
                  new List<int> {570, 888},
                  new List<int> {350, 121},
                  new List<int> {865, 105},
                  new List<int> {278, 99},
                  new List<int> {853, 177},
                  new List<int> {610, 693},
                  new List<int> {886, 996},
                  new List<int> {808, 539},
                  new List<int> {476, 307},
                  new List<int> {185, 804},
                  new List<int> {656, 414},
                  new List<int> {69, 286},
                  new List<int> {362, 812},
                  new List<int> {237, 961},
                  new List<int> {332, 495},
                  new List<int> {217, 123},
                  new List<int> {878, 174},
                  new List<int> {450, 408},
                  new List<int> {621, 942},
                  new List<int> {490, 916},
                  new List<int> {975, 942},
                  new List<int> {695, 698},
                  new List<int> {726, 837},
                  new List<int> {136, 538},
                  new List<int> {938, 730},
                  new List<int> {966, 31},
                  new List<int> {392, 644},
                  new List<int> {653, 164},
                  new List<int> {965, 158},
                  new List<int> {323, 688},
                  new List<int> {951, 34},
                  new List<int> {225, 982},
                  new List<int> {951, 554},
                  new List<int> {582, 437},
                  new List<int> {784, 122},
                  new List<int> {273, 465},
                  new List<int> {179, 423},
                  new List<int> {327, 863},
                  new List<int> {102, 79},
                  new List<int> {608, 175},
                  new List<int> {219, 820},
                  new List<int> {84, 873}, // Ans: 11
            };

            maxEnvelops = MaxEnvelops(list);
            Console.WriteLine("Max envelops that can be enclosed with each other is {0}", maxEnvelops);
        }

        private static int MaxEnvelops(List<List<int>> list)
        {
            //Dp[] of size = list.Count
            int[] dp = new int[list.Count];
            //0th index means empty subsequence, return 1;
            dp[0] = 1;

            //Sort by height followed by width
            var sortedList = list.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();

            //For the dp [] count
            for (int i = 1; i < sortedList.Count; i++)
            {
                //If no elems in subsequence, then it is subsequence of the number itself. So set it as 1 initially.
                dp[i] = 1;

                //For each elem, compare if prev elem is < curr elem, then add subsequence count of prev elem + 1(curr elem).
                for (int j = i-1; j >= 0; j--)
                {
                    // Width of prev elem(j)[1] and height of prev elem[j][0] is < width of curr elem(i) and height of curr elem
                    if(sortedList[j][1] < sortedList[i][1] && sortedList[j][0] < sortedList[i][0])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
            }

            //Each elem will have count of subsequence ending at the number(including number).
            //Get max of all the subsequences from array for each index.
            return dp.Max();
        }
    }
}
