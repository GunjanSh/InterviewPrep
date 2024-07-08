using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Graph
{
    internal class CountConnectedComponents_UndirectedGraph
    {
        public static void CountConnectedComponents()
        {
            int n = 3;
            int[][] edges = new int[2][] { new int[] { 0, 1 }, new int[] { 0, 2 } };

            int count = CountComponents(n, edges);
        }

        public static int CountComponents(int n, int[][] edges)
        {
            List<int>[] adjList = new List<int>[n];

            for (int vertex = 0; vertex < n; vertex++)
            {
                //Initialize each index to avoid Null reference exception - NRE
                adjList[vertex] = new List<int>();
            }

            for (int idx = 0; idx < edges.Length; idx++)
            {
                var src = edges[idx][0];
                var dest = edges[idx][1];

                adjList[src].Add(dest);
                adjList[dest].Add(src);
            }

            bool[] visited = new bool[n];
            int count = 0;

            for (int vertex = 0; vertex < n; vertex++)
            {
                if (!visited[vertex])
                {
                    Dfs(vertex, adjList, visited);
                    count++;
                }
            }

            return count;
        }

        static void Dfs(int vertex, List<int>[] adjList, bool[] visited)
        {
            visited[vertex] = true;

            foreach (var neighbor in adjList[vertex])
            {
                if (!visited[neighbor])
                {
                    Dfs(neighbor, adjList, visited);
                }
            }
        }
    }
}
