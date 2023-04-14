using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class AnySubsequenceWithSumK
    {
        public static void AnySubsequenceWithSum()
        {
            List<int> list = new List<int> { 1, 2, 1 };
            int sum = 2;

            List<int> tempList = new List<int>();
            List<List<int>> subsList = new List<List<int>>();

            GetSubsequence(0, 0, sum, list, tempList, subsList);
        }

        static bool GetSubsequence(int index, int target, int sum, List<int> input, List<int> tempList, List<List<int>> subsequences)
        {
            if (index == input.Count)
            {
                if (target == sum)
                {
                    subsequences.Add(tempList);
                    return true;
                }

                return false;
            }

            tempList.Add(input[index]);
            target += input[index];
    
            if (GetSubsequence(index+1, target, sum, input, tempList, subsequences))
            {
                return true;
            }

            tempList.Remove(input[index]);
            target -= input[index];

            if (GetSubsequence(index + 1, target, sum, input, tempList, subsequences))
            {
                return true;
            }

            return false;

        }
    }
}
