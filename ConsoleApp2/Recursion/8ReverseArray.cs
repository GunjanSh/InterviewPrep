using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class ReverseArray
    {
        public static void Reverse()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };

            TwoPointers(arr);

            Console.WriteLine();

            Console.WriteLine("Reversed array using two pointers and recursion");

            TwoPointersRecursion(0, arr.Length - 1, arr);

            for (int idx = 0; idx < arr.Length; idx++)
            {
                Console.Write("{0} ", arr[idx]);
            }

            Console.WriteLine();

            Console.WriteLine("Reversed array using single pointer and recursion");

            SinglePointerRecursion(0, arr.Length, arr);

            for (int idx = 0; idx < arr.Length; idx++)
            {
                Console.Write("{0} ", arr[idx]);
            }

            Console.WriteLine();

            // TO DO: Need to make it work using swap function.
            //TwoPointersUsingSwap(arr);
        }

        static void SinglePointerRecursion(int index, int length, int[] arr)
        {
            if (index >= length/2)
            {
                return;
            }

            int temp = arr[index];
            arr[index] = arr[length - index - 1];       //(n-i-1)
            arr[length - index - 1] = temp;

            SinglePointerRecursion(index + 1, length, arr);
        }

        static void TwoPointersRecursion(int left, int right, int[] arr)
        {
            if (left >= right)
            {
                return;
            }

            // Swap
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            TwoPointersRecursion(left + 1, right - 1, arr);
        }

        static void TwoPointers(int[] arr)
        {
            for(int left = 0, right = arr.Length-1 ; left <= right; left++, right--)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }

            Console.WriteLine("Reversed array using two pointers");

            for (int idx = 0; idx < arr.Length; idx++)
            {
                Console.Write("{0} ", arr[idx]);
            }

            Console.WriteLine();
        }

        static void TwoPointersUsingSwap(int[] arr)
        {
            int left = 0;
            int right = arr.Length-1;

            for (; left <= right; left++, right--)
            {
                Swap(ref arr[left], ref arr[right]);
            }

            Console.WriteLine("Reversed array using two pointers");

            for (int idx = 0; idx < arr.Length; idx++)
            {
                Console.Write("{0} ", arr[idx]);
            }

            Console.WriteLine();
        }

        static void Swap(ref int first,ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}
