using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Sorting
{
    public class MergeSortAlgorithm
    {
        public static void Sort()
        {
            var list = new List<int> { 3, 1, 2, 4, 1, 5, 6, 2, 4 };

            Console.WriteLine("Before sorting using merge sort");
            Console.WriteLine("UnSorted Data - {0}", string.Join(",", list));

            MergeSort(list, 0, list.Count - 1);

            Console.WriteLine("After sorting using merge sort");
            Console.WriteLine("Sorted Data - {0}", string.Join(",", list));
        }

        public static void MergeSort(List<int> list, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int mid = (low + high) / 2;

            MergeSort(list, low, mid);
            MergeSort(list, mid + 1, high); //O(log n)

            Merge(list, low, mid, high);  //O(n), Space is O(n) for the temp array.
        }

        public static void Merge(List<int> list, int low, int mid, int high)
        {
            List<int> temp = new List<int>();

            int left = low, right = mid + 1;

            while (left <= mid && right <= high)
            {
                if (list[left] <= list[right])
                {
                    temp.Add(list[left]);
                    left++;
                }
                else
                {
                    temp.Add(list[right]);
                    right++;
                }
            }

            while (left <= mid)
            {
                temp.Add(list[left]);
                left++;
            }

            while (right <= high)
            {
                temp.Add(list[right]);
                right++;
            }

            for (int i = low; i <= high; i++)
            {
                list[i] = temp[i - low];
            }

            // This will override the entire list with the data in temp which will always be less than or equal to the list size.
            //list = temp;
        }
    }
}
