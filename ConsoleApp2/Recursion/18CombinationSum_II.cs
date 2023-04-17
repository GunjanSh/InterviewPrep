using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class _18CombinationSum_II
    {
        public static void CombinationSum()
        {
            List<int> numbers = new List<int> {10, 1, 2, 7, 6, 1, 5 };
            int target = 8;
            //Ouput --> [1, 1, 6] [1, 2, 5] [1, 7] [2, 6]
            //Combination sum without duplicates.

            List<List<int>> output = new List<List<int>>();
            List<int> currentList = new List<int>();
            //int initialTarget = 0;

            //Sort the list as the answer is expected in sorted/lexicographically order.
            numbers.Sort();
            //GetCombinations(numbers.DistinctBy(x => x).ToList(), 0, output, currentList, target, ref initialTarget);
            GetCombinationsTwo(numbers, 0, target, currentList, output);
        }

        private static void GetCombinationsTwo(List<int> numbers, int index, int target, List<int> currentList, List<List<int>> output)
        {
            if (target == 0)
            {
                output.Add(new List<int>(currentList));
                return;
            }

            for (int idx = index; idx < numbers.Count; idx++)
            {
                // numbers[idx] == numbers[idx - 1] , dont pick consecutive elements which are same
                // idx > index, for the recursion call, if it is the first index in the recursive call, then pick. Recursion call is starting from that index.
                if (idx > index && numbers[idx] == numbers[idx - 1]) continue;

                if (numbers[idx] > target)
                {
                    break;
                }

                currentList.Add(numbers[idx]);

                // Should be idx+1, not index+1, since you are trying all the elements in the array starting from index to n-1.
                GetCombinationsTwo(numbers, idx + 1, target - numbers[idx], currentList, output);

                currentList.Remove(numbers[idx]);
            }
        }

        /// <summary>
        /// Previous combination sum approach will give redundant lists, to get distinct you need to add data to hashset.
        /// TC will increase with hashset.
        /// Use second recursion pattern where you always select the next index if allowed(in terms of target).
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="index"></param>
        /// <param name="output"></param>
        /// <param name="currentList"></param>
        /// <param name="target"></param>
        /// <param name="ongoingTarget"></param>
        private static void GetCombinations(List<int> numbers, int index, List<List<int>> output, List<int> currentList, int target, ref int ongoingTarget)
        {
            if (ongoingTarget == target)
            {
                output.Add(new List<int>(currentList));
                return;
            }

            int remainingTarget = target - ongoingTarget;

            // If we do not give this condition, it will pick number from the same index until we get stack overflow exception.
            // Pick until the remaining target.

            if (numbers[index] <= remainingTarget)
            {
                currentList.Add(numbers[index]);
                ongoingTarget += numbers[index];

                GetCombinations(numbers, index + 1, output, currentList, target, ref ongoingTarget);

                currentList.Remove(numbers[index]);
                ongoingTarget -= numbers[index];
            }

            //GetCombinations(numbers, index + 1, output, currentList, target, ref ongoingTarget);
        }
    }
}
