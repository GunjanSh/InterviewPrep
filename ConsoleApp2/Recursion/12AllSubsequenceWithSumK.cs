using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    // 1 2 1 Sum = 2
    internal class AllSubsequenceWithSumK
    {
        public static void GetSubsequencesWithSum()
        {
            List<int> list = new List<int> { 1, 2, 1 };
            int sum = 2;

            List<List<int>> subsList = new List<List<int>>();
            List<int> tempList = new List<int>();

            Subsequence(0, sum, sum, list, tempList, subsList);

            subsList = new List<List<int>>();
            tempList = new List<int>();

            SubsequenceStriver(0, 0, sum, list, tempList, subsList);
        }

        static void Subsequence(int index, int target, int sum, List<int> input, List<int> tempList, List<List<int>> subsequenceList)
        {
            //if (target == 0 && index == input.Count)
            //{
            //    subsequenceList.Add(new List<int>(tempList));
            //    return;
            //}

             if (index >= input.Count)
            {
                if (target == 0)
                {
                    subsequenceList.Add(new List<int>(tempList));
                }

                return;
            }

            if (target >= input[index])
            {
                tempList.Add(input[index]);
                Subsequence(index + 1, target - input[index], sum,  input, tempList, subsequenceList);
                tempList.Remove(input[index]);

                if (target + input[index] <= sum)
                {
                    target += input[index];
                }
            }

            Subsequence(index+1, target, sum, input, tempList, subsequenceList);
        }

        // Removes additional checks from previous approach / method.
        static void SubsequenceStriver(int index, int target, int sum, List<int> input, List<int> tempList, List<List<int>> subsequenceList)
        {
            if (index == input.Count)
            {
                if (target == sum)
                {
                    subsequenceList.Add(new List<int>(tempList));
                }

                return;
            }

            tempList.Add(input[index]);
            target += input[index];

            SubsequenceStriver(index + 1, target, sum, input, tempList, subsequenceList);

            tempList.Remove(input[index]);
            target -= input[index];


            SubsequenceStriver(index + 1, target, sum, input, tempList, subsequenceList);
        }
    }
}
