using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static class ConnectedRopes
    {
        internal static void ConnectRopes()
        {
            //var ropes = new int[] { 3, 2, 1, 5 };
            var ropes = new int[] { 4, 3, 2, 6 };

            var cost = FindMinCost(ropes);
        }

        static int FindMinCost(int[] ropes)
        {
            int minCost = 0;

            PriorityQueue<int, int> q = new PriorityQueue<int, int>();

            for (int i = 0; i < ropes.Length; i++)
            {
                q.Enqueue(ropes[i], ropes[i]);
            }

            while (q.Count > 1)
            {
                var item1 = q.Dequeue();
                var item2 = q.Dequeue ();
                var cost = item1 + item2;

                minCost += (cost);
                q.Enqueue(cost, cost);
            }

            //minCost += q.Dequeue();

            return minCost;
        }
    }
}
