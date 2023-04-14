using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Graph
{
    /*
     Problem Description

    Given an undirected graph having A nodes labelled from 1 to A with M edges given in a form of matrix B of size M x 2 where (B[i][0], B[i][1]) represents two nodes B[i][0] and B[i][1] connected by an edge.
    Find whether the graph contains a cycle or not, return 1 if cycle is present else return 0.

    NOTE:
    The cycle must contain atleast three nodes.
    There are no self-loops in the graph.
    There are no multiple edges between two nodes.
    The graph may or may not be connected.
    Nodes are numbered from 1 to A.
    Your solution will run on multiple test cases. If you are using global variables make sure to clear them.


    Problem Constraints
    1 <= A, M <= 3*105
    1 <= B[i][0], B[i][1] <= A

    Input Format
    The first argument given is an integer A representing the number of nodes in the graph.
    The second argument given is an matrix B of size M x 2 which represents the M edges such that there is a edge between node B[i][0] and node B[i][1].

    Output Format
    Return 1 if cycle is present else return 0.
     */
    internal class CycleInUndirectedGraph
    {
        public static void Solve()
        {
            int vertices = 5;
            List<List<int>> edges = new List<List<int>>
                                                    {
                                                        new List<int> {1, 2},
                                                        new List<int> {1, 3},
                                                        new List<int> {2, 3},
                                                        new List<int> {1, 4},
                                                        new List<int> {4, 5},
                                                    }; // Ans: 1

            int hasCycle = CheckCycle(edges, vertices);
            Console.WriteLine("Graph with {0} vertices has cycles: {1}", vertices, hasCycle);

            vertices = 3;
            edges = new List<List<int>>
                                                    {
                                                        new List<int> {1, 2},
                                                        new List<int> {1, 3},
                                                    }; // Ans: 0

            hasCycle = CheckCycle(edges, vertices);
            Console.WriteLine("Graph with {0} vertices has cycles: {1}", vertices, hasCycle);
        }

        static int CheckCycle(List<List<int>> edges, int vertices)
        {
            bool[] visited = new bool[vertices+1];

            List<int>[] adjList = new List<int>[vertices+1];
            for (int i = 0; i <= vertices; i++)
            {
                adjList[i] = new List<int>();
            }

            for (int i = 0; i < edges.Count; i++)
            {
                var src = edges[i][0];
                var dest = edges[i][1];

                adjList[src].Add(dest);
                adjList[dest].Add(src);
            }

            for (int i = 1; i <= vertices; i++)
            {
                if(!visited[i])
                {
                    if (IsCyclic(i, -1, visited, adjList))
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        static bool IsCyclic(int vertex, int parent, bool[] visited, List<int>[] adjList)
        {
            visited[vertex] = true;

            //var adjList = edges.Where(x => x.Contains(vertex)).SelectMany(x => x);
            //var adjList = edges.Where(x => x.Any(y => y == vertex));
            foreach (var item in adjList[vertex])
            {
                if(!visited[item])
                {
                    if (IsCyclic(item, vertex, visited, adjList))
                    {
                        return true;
                    }
                }
                else if (item != parent)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
