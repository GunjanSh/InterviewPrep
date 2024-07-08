using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Recursion
{
    internal class _21PrintAllPermutationsOfStringOrArray_SpaceOptimized
    {
        public static void GetAllPermutations()
        {
            List<int> numbers = new List<int> { 1, 2, 3 };
            //Output --> { {1 ,2 ,3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1} }

            List<List<int>> output = new List<List<int>>();

            GetPermutations(numbers, output, 0);
        }

        static void GetPermutations(List<int> input, List<List<int>> output, int index)
        {
            if (index == input.Count)
            {
                output.Add(new List<int>(input));
                return;
            }

            /*
                                                    [1, 2, 3]
                                                    /     |      \
                                                  /       |       \
                                           s(1-1)  s(1-2)   s(1-3)
                                       /   \             /    \        /   \
                              s(2-2)  s(2-3)         
                                /             \
                            s(3,3)      s(2-2)

            */
            
            // Approach: Swap 1 with 1, swap 1 with 2, swap 1 with 3
            // For left recursion, swap 2 with 2, swap 2 with 3
            
            //NOTE: For loop iterates from index to n-1
            for(int idx = index; idx < input.Count; idx++)
            {
                //Swap the idx with index being passed and back track
                Swap(idx, index, input);
                //NOTE: Move to the next index in the array, hence its index+1 and not idx.
                GetPermutations(input, output, index+1);
                Swap(idx, index, input);
            }
        }

        static void Swap(int i, int j, List<int> numbers)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
