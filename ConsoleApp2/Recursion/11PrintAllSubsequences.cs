using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
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
