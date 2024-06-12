using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Sorting
{
    // TC: Best - O(n log n) when list is sorted, Avg - O(n log n), Worst - O(n^2)
    // SC: O(log n)

    internal class QuickSort
    {
        public static void Sort()
        {
            List<int> list = new() { 89, 76, 45, 92, 67, 12, 99 };

            Console.WriteLine("Before sorting using quick sort");
            Console.WriteLine("UnSorted Data - {0}", string.Join(",", list));

            QuickSortAlgo(list, 0, list.Count - 1);

            Console.WriteLine("After sorting using quick sort");
            Console.WriteLine("Sorted Data - {0}", string.Join(",", list));
        }

        static void QuickSortAlgo(List<int> list, int low, int high)
        {
            if (low < high)
            {
                //Find pivot
                int partitionIndex = FindPivot(list, low, high);

                //Quick sort the left half of pivot
                QuickSortAlgo(list, low, partitionIndex - 1);

                //Quick sort the right half of pivot
                QuickSortAlgo(list, partitionIndex + 1, high);
            }
        }

        static int FindPivot(List<int> list, int low, int high)
        {
            //NOTE: Picking 1st elem as the pivot.
            int pivot = list[low];
            int i = low, j = high;

            while (i < j)
            {
                while (list[i] <= pivot && i <= high)
                {
                    i++;
                }

                while (list[j] > pivot && j >= low)
                {
                    j--;
                }

                if (i < j)
                {
                    // Swap list[i] and list[j]
                    int temp = list[j];
                    list[j] = list[i];
                    list[i] = temp;
                }
            }

            // Swap the pivot elem with list[j] when j crosses i
            int tem = list[j];
            list[j] = pivot;
            list[low] = tem;

            return j;
        }
    }
}
