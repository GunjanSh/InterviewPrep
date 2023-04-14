using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Graph
{
    internal class TopologicalSort
    {
        /*
            Problem Description
            Given an directed acyclic graph having A nodes. A matrix B of size M x 2 is given which represents the M edges such that there is a edge directed from node B[i][0] to node B[i][1].
            Topological sorting for Directed Acyclic Graph (DAG) is a linear ordering of vertices such that for every directed edge uv, vertex u comes before v in the ordering. 
            Topological Sorting for a graph is not possible if the graph is not a DAG.

            Return the topological ordering of the graph and if it doesn't exist then return an empty array.

            If there is a solution return the correct ordering. If there are multiple solutions print the lexographically smallest one.
            Ordering (a, b, c) is said to be lexographically smaller than ordering (e, f, g) if a < e or if(a==e) then b < f and so on.

            NOTE:

            There are no self-loops in the graph.
            There are no multiple edges between two nodes.
            The graph may or may not be connected.
            Nodes are numbered from 1 to A.
            Your solution will run on multiple test cases. If you are using global variables make sure to clear them.

            Problem Constraints
            2 <= A <= 104
            1 <= M <= min(100000,A*(A-1))
            1 <= B[i][0], B[i][1] <= A

            Input Format
            The first argument given is an integer A representing the number of nodes in the graph.
            The second argument given a matrix B of size M x 2 which represents the M edges such that there is a edge directed from node B[i][0] to node B[i][1].

            Output Format
            Return a one-dimensional array denoting the topological ordering of the graph and it it doesn't exist then return empty array.
         */

        public static void Solve()
        {
            List<List<int>> matrix = new List<List<int>>
            {
                new List<int>{ 6, 3},
                new List<int>{ 6, 1},
                new List<int>{ 5, 1},
                new List<int>{ 5, 2},
                new List<int>{ 3, 4},
                new List<int>{ 4, 2 },
            }; //Ans:  [5, 6, 1, 3, 4, 2]

            int vertices = 6;

            List<int> sorted = TopoSort(vertices, matrix);

            matrix = new List<List<int>>
            {
                  new List<int>{ 1, 4 },
                  new List<int>{ 1, 2 },
                  new List<int>{ 4, 2 },
                  new List<int>{ 4, 3 },
                  new List<int>{ 3, 2 },
                  new List<int>{ 5, 2 },
                  new List<int>{ 3, 5 },
                  new List<int>{ 8, 2 },
                  new List<int>{ 8, 6 },
            }; //Ans:  [1 4 3 5 7 8 2 6 ]

            vertices = 8;

           sorted = TopoSort(vertices, matrix);

        }

        static List<int> TopoSort(int vertices, List<List<int>> edges)
        {
            List<int> list = new List<int>();
            PriorityQueue<int, int> queue = new PriorityQueue<int, int >();
            //Vertices are numbered from 1 to N, initialize array with vertices+1.
            List<int>[] adjList = new List<int>[vertices + 1];
            int[] indegree = new int[vertices + 1];

            for (int vertex = 0; vertex <= vertices; vertex++)
            {
                //Initialize each index to avoid Null reference exception - NRE
                adjList[vertex] = new List<int>();
            }

            //Create adjacency list for directed graph
            for (int edge = 0; edge < edges.Count; edge++)
            {
                var src = edges[edge][0];
                var dest = edges[edge][1];

                adjList[src].Add(dest);

                //Maintain indegree count for vertex which is destination, ex u-->v, v is destination            
                indegree[dest] += 1;
            }

            for (int vertex = 1; vertex <= vertices; vertex++)
            {
                //Pick vertices with indegree as 0, that means it has no dependencies.
                if (indegree[vertex] == 0)
                {
                    queue.Enqueue(vertex, vertex);
                }
            }

            int numberOfVisited = 0;
            while (queue.Count > 0)
            {
                int top = queue.Dequeue();
                list.Add(top);
                numberOfVisited++;

                //For each vertex in queue, check neighbours of the vertex in sorted order.
                foreach (int vertex in adjList[top].OrderBy(x => x))
                {
                    //Decrease indegree of vertex as it is already added to output list.
                    indegree[vertex] -= 1;

                    //If the indegree of vertex reaches 0, add it to queue.
                    if (indegree[vertex] == 0)
                    {
                        queue.Enqueue(vertex, vertex);
                    }
                }
            }

            //This is to check if graph has a cycle/loop.
            if (numberOfVisited != vertices)
            {
                return new List<int>();
            }

            return list;
        }
    }
}
