using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class TopKElements
    {
        public static void FindTopKElements()
        {
            int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
            int k = 2;

            var output = TopKFrequent(nums, k);

        }

        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            var queue = new PriorityQueue<(int key, int freq), (int key, int freq)>(
             Comparer<(int key, int freq)>.Create((x, y) => y.freq.CompareTo(x.freq))
            );

            foreach (var num in nums)
            {
                if (!freqMap.ContainsKey(num))
                {
                    freqMap[num] = 1;
                }
                else
                {
                    freqMap[num]++;
                }
            }

            foreach (var freq in freqMap)
            {
                queue.Enqueue((freq.Key, freq.Value), (freq.Key, freq.Value));
            }

            int[] output = new int[k];

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("{0} - {1}", queue.Peek().key, queue.Peek().freq);
                output[i] = queue.Dequeue().key;
            }

            return output;
        }
    }
}
