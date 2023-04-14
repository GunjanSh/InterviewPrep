using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.TwoPointers
{
    internal class CountPairsWithGivenDifference
    {
        public static void Solve()
        {
            List<int> list = new List<int> {8, 5, 1, 10, 5, 9, 9, 3, 5, 6, 6, 2, 8, 2, 2, 6, 3, 8, 7, 2, 5, 3, 4, 3, 3, 2, 7, 9, 6, 8, 7, 2, 9, 10, 3, 8, 10, 6, 5, 4, 2, 3 };
            int key = 3;

            var count = CountDistinctPairsWithDifference(list, key);    // 7

            list = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            key = 0;

            count = CountDistinctPairsWithDifference(list, key);    //1

            list = new List<int> { 1, 1, 1, 2, 2 };
            key = 0;

            count = CountDistinctPairsWithDifference(list, key);   //2

            list = new List<int> { 1, 2 };
            key = 0;

            count = CountDistinctPairsWithDifference(list, key);   //0
        }

        static int CountDistinctPairsWithDifference(List<int> list, int B)
        {
            var sortedList = list.OrderBy(x => x).ToList();
            //int count = 0;
            int leftPtr = 0, rightPtr = 1;
            HashSet<(int start, int end)> hs = new HashSet<(int start, int end)>();

            while (leftPtr <= rightPtr && rightPtr < sortedList.Count)
            {
                int difference = Math.Abs(sortedList[leftPtr] - sortedList[rightPtr]);

                if (difference < B)
                {
                    rightPtr++;
                }
                else if (difference > B)
                {
                    leftPtr++;

                    if (leftPtr == rightPtr)
                    {
                        rightPtr++;
                    }
                }
                else
                {
                    //count++;
                    if (!hs.Contains((sortedList[leftPtr], sortedList[rightPtr])))
                    {
                        hs.Add((sortedList[leftPtr], sortedList[rightPtr]));
                    }
                    leftPtr++;
                    rightPtr++;
                }
            }

            return hs.Count;
        }
    }
}
