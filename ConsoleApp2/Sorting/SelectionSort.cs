using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Sorting
{
    internal class SelectionSort
    {
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
