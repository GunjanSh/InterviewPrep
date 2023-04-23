using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    // Given a list of N integers, print sum of all subsets in it.
    // Output should be printed in increasing order of sums.
    internal class _19SubsetSum
    {
        //NOTE: For a set of size n, we can have (2^n) sub-sets in total.
        public static void GetSubsetsSum()
        {
            int n = 2; // Number of items in the list.
            List<int> list = new List<int> { 2, 3 };
            // Ouput --> [0, 2, 3, 5]
            // One approach is using power set, time complexity will be (2^n * n)

            List<int> subsets = new List<int>();
            GetSubsetSum(list, n, 0, 0, subsets);
        }

        static void GetSubsetSum(List<int> list, int n, int index, int sum, List<int> subsets)
        {
            if (index == n)
            {
                subsets.Add(sum);
                return;
            }

            //Pick, then add to the sum and move to next index.
            GetSubsetSum(list, n, index + 1, sum + list[index], subsets);

            //Don't Pick, then don't add to the sum and move to next index.
            GetSubsetSum(list, n, index + 1, sum , subsets);
        }
    }
}
