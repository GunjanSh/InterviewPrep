using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.Graph
{
    /*
     *  For 4 directions
     *  rows --> -1  0  1  0
     *  cols -->  0 -1  0  1
     *  
     *  int[] rowIndices = new int[8] { -1, -1, -1, 1, 1,  1,  0,  0};
     *  int[] colIndices = new int[8]  {  0,   1, -1, 0, 1, -1, -1, 1};
     *  
     */

    public class NodeDistance
    {
        public int Distance;

        public int Node;
    }

    //////Descending Sort, Integer
    ////var queue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));

    //////Ascending Sort, Object
    ////var queue = new PriorityQueue<ObjectA, ObjectB>(Comparer<ObjectB>.Create((x, y) => x.Something.CompareTo(y.Something));

    public class NodeDistanceComparer : IComparer<NodeDistance>
    {
        public int Compare(NodeDistance x, NodeDistance y)
        {
            if (x.Distance == y.Distance)
            {
                if (x.Node == y.Node)
                    return 0;
                else if (x.Node < y.Node)
                    return -1;
                else if (x.Node > y.Node)
                    return 1;
                else
                    return -1;
            }
            else if (x.Distance < y.Distance)
                return -1;
            else if (x.Distance > y.Distance)
                return 1;
            else
                return -1;
        }
    }

    public class DistanceComparer : IComparer<Tuple<int, int>>
    {
        public int Compare(Tuple<int, int> x, Tuple<int, int> y)
        {
            if (x.Item1 == y.Item1)
            {
                if (x.Item2 == y.Item2)
                    return 0;
                else if (x.Item2 < y.Item2)
                    return 1;
                else if (x.Item2 > y.Item2)
                    return -1;
                else
                    return -1;
            }
            else if (x.Item1 < y.Item1)
                return 1;
            else if (x.Item1 > y.Item1)
                return -1;
            else
                return -1;
        }
    }

    internal class Dijkstra
    {
        public static void Solve()
        {
            int vertices = 6;
            int sourceVertex = 4;

            List<List<int>> matrix = new List<List<int>>
            {
                new List<int> {0, 4, 9},
                new List<int> {3, 4, 6},
                new List<int> {1, 2, 1},
                new List<int> {2, 5, 1},
                new List<int> {2, 4, 5},
                new List<int> {0, 3, 7},
                new List<int> {0, 1, 1},
                new List<int> {4, 5, 7},
                new List<int> {0, 5, 1},
            };

            var distance = FindShortestPath(vertices, matrix, sourceVertex);
            var distance2 = FindShortestPathUsingSortedDictionary(vertices, matrix, sourceVertex);
            //D = [7, 6, 5, 6, 0, 6]

            vertices = 7;
            sourceVertex = 2;
            matrix = new List<List<int>>
            {
                  new List<int> { 2, 4, 10 },
                  new List<int> { 3, 4, 1},
                  new List<int> { 3, 6, 1},
                  new List<int> { 1, 2, 4},
                  new List<int> { 4, 5, 6 } ,
            };

            distance2 = FindShortestPathUsingSortedDictionary(vertices, matrix, sourceVertex);
        }

        private static int[] FindShortestPath(int vertices, List<List<int>> matrix, int sourceVertex)
        {
            int[] distance = new int[vertices];
            List<(int distance, int vertex)>[] adjList = new List<(int distance, int vertex)>[vertices];
            SortedDictionary<NodeDistance, NodeDistance> sd = new SortedDictionary<NodeDistance, NodeDistance>();
            PriorityQueue<NodeDistance, NodeDistance> pq = new PriorityQueue<NodeDistance, NodeDistance>(new NodeDistanceComparer());
            PriorityQueue<(int, int), (int, int)> pq1 = new PriorityQueue<(int, int), (int, int)>(Comparer<(int, int)>.Create((x, y) => x.Item1.CompareTo(y.Item1)));
            //PriorityQueue<(int dist, int node), (int dist, int node)> pq = new PriorityQueue<(int dist, int node), (int dist, int node)>(new DistanceComparer());

            distance = Enumerable.Repeat(int.MaxValue, vertices).ToArray();

            for(int idx = 0; idx < vertices; idx++)
            {
                adjList[idx] = new List<(int distance, int vertex)>();
            }

            for(int row = 0; row < matrix.Count; row++)
            {
                int u = matrix[row][0];
                int v = matrix[row][1];
                int dist = matrix[row][2];

                // This is undirected graph.
                adjList[u].Add((dist, v));
                adjList[v].Add((dist, u));
            }

            var initDistance = new NodeDistance { Distance = 0, Node = sourceVertex };
            pq.Enqueue(initDistance, initDistance);
            sd.Add(initDistance, initDistance);
            distance[sourceVertex] = 0;

            while (pq.Count > 0)
            {
                var top = pq.Dequeue();
                var dist = top.Distance;
                var node = top.Node;

                foreach (var neighbour in adjList[node])
                {
                    // Distance of node plus edgeWeight of Node to reach neighbour, If less then update distance to reach neighbour.
                    var newDistance = dist + neighbour.distance;
                    // IMP : you need to compare distance of neighbour and update distance of neighbour if its less than current distance.
                    if (distance[neighbour.vertex] > newDistance)
                    {
                        distance[neighbour.vertex] = newDistance;
                        var newNodeDistance = new NodeDistance { Distance = newDistance, Node = neighbour.vertex };
                        pq.Enqueue(newNodeDistance, newNodeDistance);
                    }
                }
            }

            return distance;
        }

        private static int[] FindShortestPathUsingSortedDictionary(int vertices, List<List<int>> matrix, int sourceVertex)
        {
            int[] distance = new int[vertices];
            List<(int distance, int vertex)>[] adjList = new List<(int distance, int vertex)>[vertices];
            SortedDictionary<NodeDistance, NodeDistance> sd = new SortedDictionary<NodeDistance, NodeDistance>(new NodeDistanceComparer());

            distance = Enumerable.Repeat(int.MaxValue, vertices).ToArray();

            for (int idx = 0; idx < vertices; idx++)
            {
                adjList[idx] = new List<(int distance, int vertex)>();
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                int u = matrix[row][0];
                int v = matrix[row][1];
                int dist = matrix[row][2];

                // This is undirected graph.
                adjList[u].Add((dist, v));
                adjList[v].Add((dist, u));
            }

            var initDistance = new NodeDistance { Distance = 0, Node = sourceVertex };
            sd.Add(initDistance, initDistance);
            distance[sourceVertex] = 0;

            while (sd.Count > 0)
            {
                var top = sd.First().Key;
                var dist = top.Distance;
                var node = top.Node;
                sd.Remove(top);

                foreach (var neighbour in adjList[node])
                {
                    // Distance of node plus edgeWeight of Node to reach neighbour, If less then update distance to reach neighbour.
                    var newDistance = dist + neighbour.distance;
                    // IMP : you need to compare distance of neighbour and update distance of neighbour if its less than current distance.
                    if (distance[neighbour.vertex] > newDistance)
                    {
                        distance[neighbour.vertex] = newDistance;
                        var newNodeDistance = new NodeDistance { Distance = newDistance, Node = neighbour.vertex };
                        sd.Add(newNodeDistance, newNodeDistance);
                    }
                }
            }

            for (int idx = 0; idx < distance.Length; idx++)
            {
                if (distance[idx] == int.MaxValue)
                {
                    distance[idx] = -1;
                }
            }

            return distance;
        }
    }
}
