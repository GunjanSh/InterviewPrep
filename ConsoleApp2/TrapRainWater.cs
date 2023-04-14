using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class TrapRainWater
    {
        public static void GetTrappedRainWater()
        {
            var arr = new int[] { 0, 1, 0, 2 };
            var arr2 = new int[] { 1, 2 };
            var arr3 = new int[] { 1, 0, 2, 5, 1, 0, 3, 0, 0, 7 };
            var arr4 = new int[] { 1, 0, 2, 7, 1, 0, 3, 0, 0, 5 };

            //Console.WriteLine("Rain water trapped is: {0}", TrappedRainWater(arr));
            //Console.WriteLine("Rain water trapped 2 is: {0}", TrappedRainWater(arr2));
            //Console.WriteLine("Rain water trapped 3 is: {0}", TrappedRainWater(arr3));
            Console.WriteLine("Rain water trapped 3 is: {0}", TrappedRainWater(arr4));

        }

        public static int TrappedRainWater(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            int leftMax = 0, rightMax = 0;
            int count = 0;

            while (left <= right)
            {
                if (arr[left] <= arr[right])
                {
                    if (arr[left] >= leftMax)
                    {
                        leftMax = arr[left];
                    }
                    else
                    {
                        count += leftMax - arr[left];
                    }

                    left++;
                }
                else
                {
                    if (arr[right] >= rightMax)
                    {
                        rightMax = arr[right];
                    }
                    else
                    {
                        count += rightMax - arr[right];
                    }

                    right--;
                }
            }

            return count;
        }
    }
}
