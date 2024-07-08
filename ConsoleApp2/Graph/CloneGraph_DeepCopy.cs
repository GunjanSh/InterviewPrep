using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.Graph
{
    // Definition for a Node.
    public class GraphNode
    {
        public int val;
        public IList<GraphNode> neighbors;

        public GraphNode()
        {
            val = 0;
            neighbors = new List<GraphNode>();
        }

        public GraphNode(int _val)
        {
            val = _val;
            neighbors = new List<GraphNode>();
        }

        public GraphNode(int _val, List<GraphNode> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution
    {
        public GraphNode CloneGraph(GraphNode node)
        {
            List<GraphNode> visited = new List<GraphNode>();

            return Dfs(node, visited);
        }

        GraphNode Dfs(GraphNode node, List<GraphNode> visited)
        {
            visited.Contains(node, EqualityComparer<GraphNode>.Default);
            if (visited.Contains(node))
            {
                return visited.FirstOrDefault(x => x.val == node.val);
            }

            visited.Add(node);
            GraphNode root = new GraphNode(node.val);
            root.neighbors = new List<GraphNode>();

            foreach (var nd in node.neighbors)
            {
                root.neighbors.Add(Dfs(nd, visited));
            }

            return root;
        }
    }

    internal class CloneGraph_DeepCopy
    {
        public static void CloneGraph()
        {
            GraphNode root = new GraphNode(1);
            root.neighbors = new List<GraphNode> { 
                    new GraphNode(2, new List<GraphNode> { 
                            new GraphNode(3, new List<GraphNode> {
                                    new GraphNode(2),
                                    new GraphNode(4),
                                }),
                            new GraphNode(1, new List<GraphNode> { 
                                    new GraphNode(2),
                                    new GraphNode(4),
                                }),
                        }),
                    new GraphNode(4, new List<GraphNode> {
                            new GraphNode(3, new List<GraphNode> {
                                    new GraphNode(2),
                                    new GraphNode(4),
                            }),
                            new GraphNode(1, new List<GraphNode> {
                                    new GraphNode(2),
                                    new GraphNode(4),
                            }),
                        } ),                
                };

            Solution sln = new Solution();
            sln.CloneGraph(root);
        }
    }
}
