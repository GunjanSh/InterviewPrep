using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Arrays
{
    internal class FindDuplicatesInArray
    {
        // Find duplicates and return the duplicate number and the missing number.
        // NOTE: numbers start from 1 to N.

        public static void FindDuplicates()
        {
            int[] input = new int[] { 1, 2, 2, 4 };

            var output = FindUsingHashSetAndNaturalNumbers(input);

            input = new int[] { 2, 2 };

            output = FindUsingHashSetAndNaturalNumbers(input);

            input = new int[] { 3, 2, 2 };

            output = FindUsingHashSetAndNaturalNumbers(input);
         }

        static int[] FindUsingHashSetAndNaturalNumbers(int[] input)
        {
            int size = input.Length;
            HashSet<int> hs = new HashSet<int>();
            int[] output = new int[2];
            int sum = 0, hsSum = 0;
            var totalSum = size * (size + 1) / 2;
            
            for (int idx = 0; idx < input.Length; idx++)
            {
                if (!hs.Contains(input[idx]))
                {
                    hs.Add(input[idx]);
                    hsSum += input[idx];
                }

                sum += input[idx];
            }

            output[0] = sum - hsSum;  //Diff gives you the duplicate number
            output[1] = totalSum - hsSum; // totalSum - hash set sum, gives the missing number

            return output;
        }

        static int[] FindUsingNaturalNumbersFormula(int[] input)
        {
            int size = input.Length;
            int[] res = new int[size + 1];
            int[] output = new int[2];
            int sum = 0, dup = 0;

            foreach (var num in input)
            {
                if (res[num] == 0)
                {
                    res[num] = 1;
                }
                else
                {
                    dup = num;
                }

                sum += num;
            }

            var totalSum = size * (size + 1) / 2;

            output[0] = dup;
            output[1] = totalSum - sum + dup;

            return output;
        }

        static int[] FindUsingHashSet(int[] input)
        {
            HashSet<int> hs = new HashSet<int>();
            int[] output = new int[2];
            int duplicate = -1;

            for(int idx = 0; idx < input.Length; idx++)
            {
                if (!hs.Contains(input[idx]))
                {
                    hs.Add(input[idx]);
                }
                else
                {
                    duplicate = input[idx];                                          
                }
            }

            for(int num = 1; num <= input.Length; num++)
            {
                if (!hs.Contains(num))
                {
                    output[0] = duplicate;
                    output[1] = num;

                    break;
                }
            }

            return output;
        }

        static int[] FindDup(int[] nums)
        {
            int curr = 1;
            int[] output = new int[2];

            for (int idx = 1; idx < nums.Length; idx++)
            {
                if (nums[idx]-1 == nums[idx-1])
                {
                    curr = nums[idx]+1;
                    continue;
                }
                else
                {
                    output[0] = nums[idx];
                    output[1] = curr;
                    break;
                }
            }

            return output;
        }

    }
}
