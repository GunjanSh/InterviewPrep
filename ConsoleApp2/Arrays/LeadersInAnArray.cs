using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Arrays
{
    internal class LeadersInAnArray
    {
        public static void FindLeaders()
        {
            int[] nums = new int[] { 4, 7, 1, 0 };
            // [7, 1, 0]

            var output = FindLeadersInArray(nums);

            nums = new int[] { 10, 22, 12, 3, 0, 6 };
            // [22, 12, 6]

            output = FindLeadersInArray(nums);
        }

        static int[] FindLeadersInArray(int[] nums)
        {
            // Start iterating from the end.
            // Last elem itself is the leader, so add that to the list.

            List<int> result = new List<int>();

            int currMax = nums[nums.Length-1];
            result.Add(currMax);

            for(int idx = nums.Length-2; idx >= 0; idx--)
            {
                // Optimized
                if (nums[idx] > currMax)
                {
                    currMax = nums[idx];
                    result.Add(currMax);
                }
                //currMax = Math.Max(currMax, nums[idx]);
                //if (currMax == nums[idx])
                //{
                //    result.Add(currMax);
                //}
            }

            // Reverse to maintain the order of the original array in the output array.
            return result.Reverse<int>().ToArray();
        }
    }
}
