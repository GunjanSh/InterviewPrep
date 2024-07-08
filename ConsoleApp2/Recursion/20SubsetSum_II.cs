using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    // Given an integer array that contains duplicates, return all the possible subsets.
    // Solution should not contain duplicate subsets.

    internal class _20SubsetSum_II
    {
        public static void GetSubsets()
        {
            List<int> nums = new List<int> { 1, 2, 2 };
            //Output --> { {}, {1}, {2}, {1,2}, {2, 2}, {1, 2, 2} }

            nums.Sort();

            List<int> temp = new List<int>();
            List<List<int>> output = new List<List<int>>();

            GetSubset(nums, 0, temp, output);
        }

        static void GetSubset(List<int> input, int index, List<int> temp, List<List<int>> output)
        {
            //Since it is subset, we don't have to check for base case.

            output.Add(new List<int>(temp));
            //if (index == list.Count)
            //{
            //    output.Add(new List<int>(temp));
            //    return;
            //}

            //NOTE: loop starts from index passed and not 0.
            for (int i = index; i < input.Count; i++)
            {
                //Can either write (i > index) or (i != index)
                if (i > index && input[i] == input[i - 1]) continue;

                temp.Add(input[i]);
                GetSubset(input, i + 1, temp, output);
                temp.Remove(input[i]);

                //In this pattern, we don't have to call the method again.
                //GetSubset(list, i + 1, temp, output);
            }
        }
    }
}
