using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Sorting
{
    // Take an element and place it in its correct order.
    // Start from the first element and keep swapping elements if found greater and until elem is placed in its correct order/position.
    // TC: Best - O(n) when list is sorted, Avg - O(n^2), Worst - O(n^2)
    // SC: O(1)
    internal class InsertionSort
    {
        public static void Sort()
        {
            List<int> list = new() { 89, 76, 45, 92, 67, 12, 99 };

            Console.WriteLine("Before sorting using insertion sort");
            Console.WriteLine("UnSorted Data - {0}", string.Join(",", list));

            InsertionSortAlgo(list);

            Console.WriteLine("After sorting using insertion sort");
            Console.WriteLine("Sorted Data - {0}", string.Join(",", list));
        }

        static void InsertionSortAlgo(List<int> list)
        {
            for(int i = 0; i < list.Count-1; i++)
            {
                int j = i;

                //NOTE: j > 0 and not >= as it will give IndexOutOfBoundsException for list[j-1].
                while ( j > 0 && list[j-1] < list[j])
                {
                    int temp = list[j - 1];
                    list[j - 1] = list[j];
                    list[j] = temp;
                    j--;
                }
            }
        }
    }
}
