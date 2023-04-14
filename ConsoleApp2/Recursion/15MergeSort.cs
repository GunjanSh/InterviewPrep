using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class MergeSort
    {
        public static void MergeSortAlgo()
        {
            List<int> numbers = new List<int> { 3, 1, 2, 4, 1, 5, 2, 6, 4 };

            Divide(numbers, 0, numbers.Count - 1);
        }

        private static void Divide(List<int> numbers, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int mid = (low + high) / 2;

            Divide(numbers, low, mid);
            Divide(numbers, mid + 1, high);

            Merge(numbers, low, mid, high);
        }

        private static void Merge(List<int> numbers, int low, int mid, int high)
        {
            int left = low;
            int right = mid + 1;
            List<int> mergedList = new List<int>();
            
            while (left <= mid && right <= high)
            {
                if (numbers[left] <= numbers[right])
                {
                    mergedList.Add(numbers[left++]);
                    //left++;
                }
                else
                {
                    mergedList.Add(numbers[right++]);
                    //right++;
                }
            }

            while (left <= mid)
            {
                mergedList.Add(numbers[left++]);
            }

            while (right <= high)
            {
                mergedList.Add(numbers[right++]);
            }

            // We are sorting elements from the indices from low to high, do not just replace the original list with temp list.
            // Temp list will not have all elements from original list, it will only have data from low to high.
            // So subtract current index with low to get the actual index in original list.

            for (int idx = low; idx <= high; idx++)
            {
                numbers[idx] = mergedList[idx - low];
            }
        }
    }
}
