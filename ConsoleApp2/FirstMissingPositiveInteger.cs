using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class FirstMissingPositiveInteger
    {
        /// <summary>
        /// Finds the first missing positive integer.
        /// TC : O(n)
        /// SC : O(n)
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static int FindFirstMissingPositiveInteger(List<int> list)
        {
            int n = list.Count;

            int[] res = new int[list.Count];

            for (int i = 0; i < n; i++)
            {
                if (list[i] > 0 && list[i] <= n)
                {
                    res[list[i] - 1] = list[i];
                }

            }

            for (int i = 0; i < list.Count; i++)
            {
                if (res[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return n + 1;
        }

        /// <summary>
        /// Finds the first missing positive integer optimized.
        /// TC : O(n)
        /// SC : O(1)
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static int FindFirstMissingPositiveIntegerOptimized(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // Loop to check boundary
                // condition and for swapping
                while (list[i] >= 1 && list[i] <= list.Count
                       && list[i] != list[list[i] - 1])
                {

                    int temp = list[list[i] - 1];
                    list[list[i] - 1] = list[i];
                    list[i] = temp;
                }
            }

            // Finding which index has value less than n
            for (int i = 0; i < list.Count; i++)
                if (list[i] != i + 1)
                    return (i + 1);

            // If array has values from 1 to n
            return (list.Count + 1);
        }
    }
}
