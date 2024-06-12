using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Sorting
{
    internal class SelectionSort
    {
        // Select the minimum elem of the list and place it at the right position.By swapping with elem at index 0.
        // Then select the minimum elem of the remaining elements and place is at index 1.
        // TC: Best - O(n^2) when list is sorted, Avg - O(n^2), Worst - O(n^2)
        // SC: O(1)
        public static void Sort()
        {
            List<int> list = new() { 89, 76, 45, 92, 67, 12, 99 };

            Console.WriteLine("Before sorting using selection sort");
            Console.WriteLine("UnSorted Data - {0}", string.Join(",", list));

            SelectionSortAlgo(list);

            Console.WriteLine("After sorting using selection sort");
            Console.WriteLine("Sorted Data - {0}", string.Join(",", list));
        }

        static void SelectionSortAlgo(List<int> list)
        {
            // Select the min of all elems and move it to index 0

            //Swap at index 0 with min elem from [0 to n-1]
            //Swap at index 1 with min elem from [1 to n-1]
            //Swap at index 2 with min elem from [2 to n-1]
            //Swap at index n-2 with min elem from [0 to n-1]. Go until n-2 index as n-1 is the last index in the array.

            // Then, select min of remaining elems from 1 to n-1 and replace with list[1]
            // Then, select min of remaining elems from 2 to n-1 and replace with list[2]
            // Go on until n-2, as n-2 to n-1 is just element, hence outer loop is until n-2.

            int n = list.Count;
            int min;

            for(int i = 0; i <= n-2; i++)
            {
                min = i;

                for(int j = i; j <= n-1; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }

                // Swap with the min value
                int temp = list[min];
                list[min] = list[i];
                list[i] = temp;
            }
        }
    }
}
