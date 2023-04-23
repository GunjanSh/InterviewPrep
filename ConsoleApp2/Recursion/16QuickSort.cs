using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class QuickSortAlgorithm
    {
        public static void QuickSortAlgo()
        {
            List<int> numbers = new List<int> { 4, 6, 2, 5, 7, 9, 1, 3, 4, 5, 5, 5, 7, 9, 1, 0, 8, 8 };
            //SortedList<int, int> sl = new SortedList<int, int>();
            //SortedDictionary<int, int> sd = new SortedDictionary<int, int>();

            QuickSort(numbers, 0, numbers.Count - 1);
        }

        private static void QuickSort(List<int> numbers, int low, int high)
        {
            //Base case, else it will not come out of the loop.
            if (low < high)
            {
                int pivot = FindPivot(numbers, low, high);

                //Do pivot-1 and pivot+1 as pivot is in its correct position while finding pivot.
                QuickSort(numbers, low, pivot - 1);
                QuickSort(numbers, pivot + 1, high);
            }
        }

        private static int FindPivot(List<int> numbers, int low, int high)
        {
            int i = low, j = high;
            int key = numbers[low];

            while (i < j)
            {
                // Do high-1 as i++ can exceed the boundary
                // numbers[i] <= key, we put duplicates on the left of the key if it is less than or equal to the key.
                while (numbers[i] <= key && i <= high-1)
                {
                    i++;
                }
                
                // Do low+1 as j-- can cause boundary issues.
                while(numbers[j] > key && j >= low+1)
                {
                    j--;
                }

                // If i > j, then it is already sorted to 2 halves, do not swap.
                if (i < j)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }

            // Array is sorted into two halves, get the pivot to its correct position. Swap low with j.
            int temp1 = numbers[j];
            numbers[j] = numbers[low];
            numbers[low] = temp1;

            return j;
        }

    }
}
