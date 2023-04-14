using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'findRoot' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY nodes as parameter.
     */

    public static void ResetMap(Dictionary<int, int> visit)
    {
        for (int i = 0; i < visit.Count; i++)
        {
            visit[i] = 0;
        }
    }

    public static int findRoot(List<List<int>> nodes)
    {
        int len = nodes.Count, cnt, val;
        Dictionary<int, (int, int)> m = new Dictionary<int, (int, int)>();
        List<int> nodeList = new List<int>();
        Dictionary<int, int> visit = new Dictionary<int, int>();
        Queue<int> q = new Queue<int>();

        if (len == 0)
        {
            return -1;
        }
        if (len == 1)
            return nodes[0][0];

        for (int i = 0; i < len; i++)
        {
            nodeList.Add(nodes[i][0]);
            visit[nodes[i][0]] = 0;
            m[nodes[i][0]] = (nodes[i][1], nodes[i][2]);
        }

        nodeList.Sort();
        for (int i = 0; i < nodeList.Count; i++)
        {
            ResetMap(visit);
            cnt = 0;
            val = nodeList[i];
            q.Enqueue(val);
            ++cnt;
            while (q.Count > 0)
            {
                int top = q.Peek();
                q.Dequeue();
                if (!visit.ContainsKey(top) || visit[top] == 0)
                {
                    return -1;
                }
                else
                {
                    visit[top] = 1;
                    if (m[top].Item1 != -1)
                    {
                        q.Enqueue(m[top].Item1);
                        ++cnt;
                    }
                    if (m[top].Item2 != -1)
                    {
                        q.Enqueue(m[top].Item2);
                        ++cnt;
                    }
                }
            }
            if ((cnt == len) && (q.Count == 0))
            {
                return val;
            }
        }
        return -1;
    }

}

class Solution
{
    public static void Main1(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int nodesRows = Convert.ToInt32(Console.ReadLine().Trim());
        int nodesColumns = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> nodes = new List<List<int>>();

        for (int i = 0; i < nodesRows; i++)
        {
            nodes.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(nodesTemp => Convert.ToInt32(nodesTemp)).ToList());
        }

        int result = Result.findRoot(nodes);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
