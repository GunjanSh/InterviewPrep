using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class _21PrintAllPermutationsOfStringOrArray
    {
        // Given an integer array of distinct values, return all the possible permutations.
        public static void GetAllPermutations()
        {
            List<int> numbers = new List<int> { 1, 2, 3 };
            //Output --> { {1 ,2 ,3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1} }

            List<int> list = new List<int>();
            List<List<int>> output = new List<List<int>>();
            bool[] visited = new bool[numbers.Count];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            GetPermutationsWorking(numbers, list, output, visited, 0);
            //GetPermutations(numbers, 0, list, output);
        }

        static void GetPermutationsWorking(List<int> input, List<int> list, List<List<int>> output, bool[] visited, int index)
        {
            if (list.Count == input.Count)
            {
                output.Add(new List<int>(list));
                return;
            }

            //NOTE: Loop starts from 0 and goes through all the elements in the array, hence visited array is used.
            for (int idx = 0; idx < input.Count; idx++)
            {
                if (!visited[idx])
                {
                    visited[idx] = true;
                    list.Add(input[idx]);

                    // NOTE: We need to increment index and not loop idx, as we are iterating over the entire array.
                    GetPermutationsWorking(input, list, output, visited, index + 1);

                    list.Remove(input[idx]);
                    visited[idx] = false;
                }
            }
        }

        static void GetPermutations(List<int> nums, List<int>list, List<List<int>> output, bool[] visited, int index)
        {
            if (list.Count == nums.Count)
            {
                output.Add(new List<int>(list));
                return;
            }

            if(index < nums.Count && !visited[index])
            {
                visited[index] = true;
                list.Add(nums[index]);

                GetPermutations(nums, list, output, visited, index + 1);
            
                list.Remove(nums[index]);
                visited[index] = false;

                GetPermutations(nums, list, output, visited, index + 1);
            }
        }

        // NOTE: THIS PICK OR NOT PICK WILL NOT WORK. AS WE NEED ALL THE PERMUTATIONS OF THE ARRAY.
        static void GetPermutations(List<int> nums, int index, List<int> list, List<List<int>> output)
        {
            if (index == nums.Count)
            {
                output.Add(new List<int>(list));
                return;
            }

            list.Add(nums[index]);
            GetPermutations(nums, index + 1, list, output);
            list.Remove(nums[index]);

            GetPermutations(nums, index + 1, list, output);
        }
    }
}
