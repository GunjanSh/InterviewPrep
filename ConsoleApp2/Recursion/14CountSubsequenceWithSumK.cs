using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class CountSubsequenceWithSumK
    {
        public static void CountSubsequences()
        {
            List<int> list = new List<int> { 1, 2, 1 };
            int sum = 2;

            List<int> tempList = new List<int>();
            List<List<int>> subsList = new List<List<int>>();
            int count = 0;

            GetSubsequence(0, 0, sum, list, tempList, subsList, ref count);

            Console.WriteLine("Number of subsequences with sum {0} is {1}", sum, count);
        }

        static void GetSubsequence(int index, int target, int sum, List<int> input, List<int> tempList, List<List<int>> subsequences, ref int count)
        {
            if (index == input.Count)
            {
                if (target == sum)
                {
                    count++;
                    subsequences.Add(tempList);
                }

                return;
            }

            tempList.Add(input[index]);
            target += input[index];

            GetSubsequence(index + 1, target, sum, input, tempList, subsequences, ref count);

            tempList.Remove(input[index]);
            target -= input[index];

            GetSubsequence(index + 1, target, sum, input, tempList, subsequences, ref count);
        }
    }
}
