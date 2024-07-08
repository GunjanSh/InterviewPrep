using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class _17CombinationSum
    {
        public static void CombinationSum()
        {
            List<int> numbers = new List<int> { 2, 3, 6, 7 };
            int target = 7;
            //Ouput --> [2, 2, 3] [7]
            //Explanation:
            // 2 and 3 are candidates, 2+2+3 = 7, Note that 2 can be used multiple times.
            //7 is a candidate, 7 = 7
            //These are the only two combinations.
            List<List<int>> output = new List<List<int>>();
            List<int> currentList = new List<int>();
            int initialTarget = 0;

            GetCombinations(numbers, 0, output, currentList, target, ref initialTarget);
        }

        private static void GetCombinations(List<int> input, int index, List<List<int>> output, List<int> currentList, int target, ref int ongoingTarget)
        {
            if (index == input.Count)
            {
                if (ongoingTarget == target)
                {
                    output.Add(new List<int>(currentList));
                    //return;
                }

                return;
            }

            int remainingTarget = target - ongoingTarget;

            // If we do not give this condition, it will pick number from the same index until we get stack overflow exception.
            // Pick until the remaining target.

            if (input[index] <= remainingTarget)
            {
                currentList.Add(input[index]);
                ongoingTarget += input[index];

                GetCombinations(input, index, output, currentList, target, ref ongoingTarget);

                currentList.Remove(input[index]);
                ongoingTarget -= input[index];
            }

            GetCombinations(input, index + 1, output, currentList, target, ref ongoingTarget);
        }
    }
}
