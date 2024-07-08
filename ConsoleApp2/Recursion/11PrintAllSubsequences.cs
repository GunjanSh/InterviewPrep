using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    /*
     * A subarray is a slice from a contiguous array (i.e., occupy consecutive positions) and inherently maintains the order of elements.
     * For example, the subarrays of array {1, 2, 3} are {1}, {1, 2}, {1, 2, 3}, {2}, {2, 3}, and {3}.
     * 
     * A subsequence is a sequence that can be derived from another sequence by deleting some elements without changing 
     * the order of the remaining elements. Subsequence need not be contiguous.
     * For example, {A, B, D} is a subsequence of sequence {A, B, C, D, E} obtained after removing {C} and {E}.
     * 
     * A subset is any possible combination of the original set. 
     * 
     */
    // https://www.techiedelight.com/difference-between-subarray-subsequence-subset/
    // https://leetcode.com/discuss/study-guide/1497123/subarrays-vs-subsequence-vs-subsets with time complexities.
    // https://www.scaler.com/topics/difference-between-subarray-subset-and-subsequence/
    // Subarray has same sequence/order of the elements as in the array. subarray can range from size 1 to size of the array
    // [1, 2, 3] --> subarrays --> [1], [2], [3], [1,2], [1,3], [2,3], [1,2,3]

    // Subset is a set with any order. All subarrays can be subsets but not vice versa.

    // Subsequence need not be contiguous

    // 3 1 2
    internal class PrintAllSubsequences
    {
        public static void PrintSubsequences()
        {
            int[] arr = new int[] { 3, 1, 2 };
            List<List<int>> subsequences = new List<List<int>>();
            List<int> list = new List<int>();

            GetSubsequences(0, arr, subsequences, list);
        }

        static void GetSubsequences(int index, int[] arr, List<List<int>> subsequences, List<int> list)
        {
            if (index >= arr.Length)
            {
                //new list, else list.remove removes from subsequences list as well as it is pass by reference.
                subsequences.Add(new List<int>(list));
                return;
            }

            list.Add(arr[index]);
            GetSubsequences(index + 1, arr, subsequences, list);
            list.Remove(arr[index]);

            GetSubsequences(index + 1, arr, subsequences, list);
        }
    }
}
