using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tries
{
    internal class MaxXORWithElemFromOtherArray
    {
        public class TrieNode
        {
            public TrieNode[] Links = new TrieNode[2];

            public bool IsEnd;

            public static bool ContainsKey(TrieNode root, int bit)
            {
                return root.Links[bit] != null;
            }

            public static void Insert(TrieNode root, int number)
            {
                TrieNode curr = root;

                for (int i = 31; i >= 0; i--)
                {
                    int setBit = (number >> i) & 1;

                    if (!TrieNode.ContainsKey(curr, setBit))
                    {
                        curr.Links[setBit] = new TrieNode();
                    }

                    curr = curr.Links[setBit];
                }

                curr.IsEnd = true;
            }

            public static int Search(TrieNode root, int number)
            {
                TrieNode curr = root;
                int xor = 0;

                for (int i = 31; i >= 0; i--)
                {
                    int setBit = (number >> i) & 1;

                    if (TrieNode.ContainsKey(curr, 1 - setBit))
                    {
                        xor |= (1 << i);
                        curr = curr.Links[1 - setBit];
                    }
                    else
                    {
                        curr = curr.Links[setBit];
                    }
                }

                return xor;
            }
        }

        public static void GetMaxXOR()
        {
            int[] nums = { 0, 1, 2, 3, 4 };
            int[][] queries = new int[][] { new int[] { 3, 1 }, new int[] { 5, 6 }, new int[] { 1, 3 } };

            var output = GetMinXORFromArray(nums, queries);

            nums = new int[] { 5, 2, 4, 6, 6, 3 };
            queries = new int[][] { new int[] { 12, 4 }, new int[] { 8, 1 }, new int[] { 6, 3 } };

            output = GetMinXORFromArray(nums, queries);
        }

        static int[] GetMinXORFromArray(int[] nums, int[][] queries)
        {
            TrieNode root = new(), curr = root;
            int[] output = new int[queries.Length];
            List<(int queryAi, List<int> details)> queriesList = new List<(int queryAi, List<int> details)>();

            for (int i = 0; i < queries.Length; i++)
            {
                queriesList.Add((queries[i][1], new List<int> { i, queries[i][0] }));
            }

            Array.Sort(nums);

           output =  Enumerable.Repeat(-1, queries.Length).ToArray();

            var sortedList = queriesList.OrderBy(x => x.queryAi).ToList();

            foreach (var details in sortedList)
            {
                curr = root;
                int i = 0;

                for (; i < nums.Length && nums[i] <= details.queryAi; i++)
                {
                        TrieNode.Insert(curr, nums[i]);
                }

                if (i != 0)
                {
                    curr = root;
                    var xor = TrieNode.Search(root, details.details.Last());
                    output[details.details.First()] = xor;
                }
            }

            return output;
        }
    }
}
