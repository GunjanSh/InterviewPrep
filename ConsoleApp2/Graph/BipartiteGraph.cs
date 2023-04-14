using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Graph
{
    internal class BipartiteGraph
    {
            public static void Solve()
            {
                int vertices = 2;
                List<List<int>> matrix = new List<List<int>>
                { 
                    new List<int> { 0, 1 },
                };

                var isBipartite = Solve(vertices, matrix); // 0

                vertices = 3;
                matrix = new List<List<int>>
                    {
                        new List<int> {0, 1},
                        new List<int> {0, 2},
                        new List<int> {1, 2},
                    };

                isBipartite = Solve(vertices, matrix); // 1

                vertices = 10;
                matrix = new List<List<int>>
                {
                   new List<int> {7, 8},
                   new List<int> {1, 2},
                   new List<int> {0, 9},
                   new List<int> {1, 3},
                   new List<int> {6, 7},
                   new List<int> {0, 3},
                   new List<int> {2, 5},
                   new List<int> {3, 8},
                   new List<int> {4, 8},
                };

                isBipartite = Solve(vertices, matrix); // 1
        }

        static int Solve(int vertices, List<List<int>> matrix)
            {
                int[] visited = new int[vertices];
                List<int>[] adjList = new List<int>[vertices];
                // int[] colors = int[2];

                for (int idx = 0; idx < vertices; idx++)
                {
                    visited[idx] = -1;
                }

                for (int idx = 0; idx < vertices; idx++)
                {
                    adjList[idx] = new List<int>();
                }

                for (int edge = 0; edge < matrix.Count; edge++)
                {
                    int u = matrix[edge][0];
                    int v = matrix[edge][1];

                    adjList[u].Add(v);
                    adjList[v].Add(u);
                }

                for (int vertex = 0; vertex < vertices; vertex++)
                {
                    if (visited[vertex] == -1)
                    {
                        if (IsBipartite(vertex, visited, adjList, 0) == false)
                        {
                            return 0;
                        }
                    }
                }

                return 1;
            }

            static bool IsBipartite(int vertex, int[] visited, List<int>[] adjList, int color)
            {
                visited[vertex] = color;

                foreach (var neighbour in adjList[vertex])
                {
                    if (visited[neighbour] == -1)
                    {
                        if (IsBipartite(neighbour, visited, adjList, 1 - color) == false)
                        {
                            return false;
                        }
                    }
                    else if (visited[neighbour] == color)
                    {
                        return false;
                    }
                }

                return true;
            }
        }


}
