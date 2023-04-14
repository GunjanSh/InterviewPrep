using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Stacks
{
    /*
         Problem Description
        Given a stack of integers A, sort it using another stack.

        Return the array of integers after sorting the stack using another stack.

        Problem Constraints
        1 <= |A| <= 5000
        0 <= A[i] <= 109

        Input Format
        The only argument is a stack given as an integer array A.

        Output Format
        Return the array of integers after sorting the stack using another stack.

        https://www.geeksforgeeks.org/sort-stack-using-temporary-stack/
     */
    internal class SortUsingStack
    {
        public static void Solve()
        {
            List<int> list = new List<int> { 5, 4, 3, 2, 1 };
            List<int> sortedList = Sort(list);  // Ans:  [1, 2, 3, 4, 5]

            list = new List<int> { 5, 17, 100, 11 };
            sortedList = Sort(list);  // Ans: [5, 11, 17, 100]
        }

        static List<int> Sort(List<int> A)
        {
            Stack<int> input = new Stack<int>();
            Stack<int> tempStack = new Stack<int>();

            //Add all list elements to stack.
            for (int idx = 0; idx < A.Count; idx++)
            {
                input.Push(A[idx]);
            }

            //While all the elements in input stack is sorted, loop
            while (input.Count > 0)
            {
                //Get one element fron input stack
                int elem = input.Pop();

                //While temp stack is having elements, check if top of temp stack is greater than
                //the current element
                while (tempStack.Count > 0 && tempStack.Peek() > elem)
                {
                    //Remove top of stack and add it to input stack.
                    input.Push(tempStack.Pop());
                }

                //Add curr elem to temp stack.
                tempStack.Push(elem);
            }

            //since elements are added in stack, reverse elements.
            var list = tempStack.ToArray();
            Array.Reverse(list);

            return list.ToList();

        }
    }
}
