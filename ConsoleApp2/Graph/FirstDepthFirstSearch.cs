using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Graph
{
    internal class FirstDepthFirstSearch
    {
        public static void Solve()
        {
            List<int> list = new List<int> { 1, 1, 2 };
            //int B = 3;
            //int C = 1;
            int B = 1;
            int C = 3;

            int pathExists = FindPath(list, B, C);
        }

        static int FindPath(List<int> A, int B, int C)
        {
            List<int>[] adjList = new List<int>[A.Count+1];
            bool[] visited = new bool[A.Count+1];
            int src = C, dest = B;

            if (src == dest)
            {
                return 1;
            }

            // since array is defined of size count+1, initialize all elements.
            for (int idx = 0; idx <= A.Count; idx++)
            {
                adjList[idx] = new List<int>();
            }

            for (int idx = 1; idx < A.Count; idx++)
            {
                //if (idx + 1 < A.Count)
                //{
                    adjList[A[idx]].Add(idx + 1);
                //}
            }

            for (int idx = 0; idx < adjList.Length; idx++)
            {
                Console.WriteLine("vertex {0}, count : {1}", idx, adjList[idx]?.Count);
            }

            bool isFound = DFS(src, dest, adjList, visited);

            return isFound ? 1 : 0;
            //return 1;
        }

        static bool DFS(int vertex, int destination, List<int>[] adjList, bool[] visited)
        {
            if (vertex == destination)
            {
                return true;
            }

            visited[vertex] = true;

            foreach (int node in adjList[vertex])
            {
                if (!visited[node])
                {
                    if (DFS(node, destination, adjList, visited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
