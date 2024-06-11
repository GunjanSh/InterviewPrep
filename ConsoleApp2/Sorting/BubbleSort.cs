using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Sorting
{
    internal class BubbleSort
    {
        // NOTE: Total number of passes for unsorted array of Length "n" will be "n-1".
        // In the 1st pass, the max element will reach the last position.

        public static void Sort()
        {
            List<int> list = new() { 89, 76, 45, 92, 67, 12, 99 };
            
            Console.WriteLine("Before sorting using bubble sort");
            Console.WriteLine("UnSorted Data - {0}", string.Join(",", list));

            BubbleSortAlgo(list);

            Console.WriteLine("After sorting using bubble sort");
            Console.WriteLine("Sorted Data - {0}", string.Join(",", list));
        }

        static void BubbleSortAlgo(List<int> list)
        {
            int n = list.Count;
            bool flag = true;

            //Outer loop is for the number of passes.
            //Total number of passes will be (arr.Length-1).
            for(int i = 0; i < n-1 && flag; i++)
            {
                flag = false;

                //for(int j = 0; j < n-i-1; j++)
                for (int j = 0; j < n - 1; j++)
                {
                    if (list[j] > list[j+1])
                    {
                        int temp = list[j];
                        list[j] = list[j+1];
                        list[j+1] = temp;
                        flag = true;
                    }
                }
            }
        }
    }
}
