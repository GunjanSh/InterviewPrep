using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Queues
{
    internal class SlidingWindowMaximum
    {
        public static void Solve()
        {
            //A = [1, 3, -1, -3, 5, 3, 6, 7]
            //B = 3
            //                [3, 3, 5, 5, 6, 7]
            //A = [1, 2, 3, 4, 2, 7, 1, 3, 6]
            //B = 6
            //7,7,7,7
            int[] arr = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            int windowSize = 3;

            //List<int> output2 = SlidingWindowOptimized(arr, windowSize);

            ////List<int> output = FindMaxList(arr, windowSize);
            //List<int> output = SlidingWindowMax(arr, windowSize);
                                    //  0  1  2   3  4  5  6  7  8  9
            arr = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };  // Ans: 10 9 8 7 6 5 4 3 2 
            windowSize = 2;

            var output = SlidingWindowOptimized(arr, windowSize);

        }

        static List<int> SlidingWindowOptimized(int[] arr, int windowSize)
        {
            //Double ended queue is supported by linked list
            LinkedList<int> deq = new LinkedList<int>();
            List<int> output = new List<int>();

            for (int idx = 0; idx < windowSize; idx++)
            {
                while (deq.Count > 0 && arr[idx] > arr[deq.Last.Value])
                {
                    deq.RemoveLast();
                }

                deq.AddLast(idx);
            }

            output.Add(arr[deq.First.Value]);
            //1, 3, -1, -3, 5, 3, 6, 7 
            for (int idx = 1; idx <= arr.Length-windowSize; idx++)
            {
                int elemToAdd = idx + windowSize - 1;
                int elemToRemove = idx - 1;// Previous elem after we moved our window.

                while (deq.Count > 0 && arr[deq.Last.Value] < arr[elemToAdd])
                {
                    deq.RemoveLast();
                }

                deq.AddLast(elemToAdd);

                if (deq.First.Value == elemToRemove)
                {
                    deq.RemoveFirst();
                }

                output.Add(arr[deq.First.Value]);
            }

            return output;
        }

        static List<int> SlidingWindowMax(int[] arr, int windowSize)
        {
            LinkedList<int> deq = new LinkedList<int>();
            List<int> output = new List<int>();

            for (int idx = 0; idx <= arr.Length-windowSize; idx++)
            {
                for(int window = idx; window <= idx+windowSize-1 ; window++)
                {
                    while (deq.Count > 0 && arr[window] >= arr[deq.Last.Value])
                    {
                        deq.RemoveLast();
                    }

                    deq.AddLast(window);
                }

                output.Add(arr[deq.First.Value]);
                deq.RemoveFirst();
            }

            return output;
        }

        static List<int> FindMaxList(int[] arr, int windowSize)
        {
            LinkedList<int> deque = new LinkedList<int>();

            for(int i = 0; i < windowSize; i++)
            {
                int currElem = arr[i];

                while (deque.Count > 0 && deque.Last.Value < currElem)
                {
                    deque.RemoveLast();
                }

                deque.AddLast(currElem);
            }

            List<int> output = new List<int> { deque.First.Value };

            for (int i = windowSize; i < arr.Length; i++)
            {
                int outGoing = arr[i - windowSize];

                while (deque.Count > 0 && deque.First.Value == outGoing)
                {
                    deque.RemoveFirst();
                }

                int incoming = arr[i];

                while (deque.Count > 0 && deque.Last.Value < incoming)
                {
                    deque.RemoveLast();
                }

                deque.AddLast(incoming);

                output.Add(deque.First.Value);
            }

            return output;
        }
    }
}
