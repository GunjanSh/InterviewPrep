using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Arrays
{
    internal class SubArrayWithGivenSum
    {
        public static void Solve()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            int sum = 5; // Ans [2, 3]

            List<int> subArr = FindSubArray(list, sum);
        }

//        ps[0] = A[0]
//i -> 1 to N - 1
//ps[i] = ps[i - 1] + A[i]

        static List<int> FindSubArray(List<int> list, int sum)
        {
            int[] arr = list.ToArray();
            int[] prefixSum = new int[arr.Length];
            IDictionary<int, int> map = new Dictionary<int, int>();
            int conSum = 0;

            //prefixSum[0] = arr[0];
            //for (int idx = 1; idx < arr.Length-1; idx++)
            //{
            //    prefixSum[idx] = prefixSum[idx - 1] + arr[idx];
            //}

            for(int idx = 0; idx < arr.Length; idx++)
            {
                conSum += arr[idx];
                
                while(conSum > sum)
                {

                }
            }

            return new List<int>();
        }
    }
}
