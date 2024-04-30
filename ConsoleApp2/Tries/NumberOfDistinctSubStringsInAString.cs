using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tries
{
    internal class NumberOfDistinctSubStringsInAString
    {
        public class TrieNode
        {
            public TrieNode[] Links = new TrieNode[26];

            public bool IsEndOfWord;

            public static bool ContainsKey(TrieNode node, char ch)
            {
                return node.Links[ch - 'a'] != null;
            }
        }

        public static void GetDistinctSubStrings()
        {
            var data = new int[][] { new int[] { 3, 1 }, new int[] { 5, 6 }, new int[] { 1, 3 } };

            var sorted = data.OrderBy(x => x[1]).ToArray();

            foreach (var num in sorted)
            {
                Console.WriteLine("{0}, {1}", num[0], num[1]);
            }

            var str = "abab";
            var counter = GetCountOfDistinctSubStrings(str);
        }

        private static int GetCountOfDistinctSubStrings(string str)
        {
            //Insert into trie starting from index 0.
            //Then index 1, maintain counter and increment when adding to Trie.

            TrieNode node = new TrieNode();
            TrieNode curr;
            int counter = 0;

            for(int i = 0; i < str.Length; i++)
            {
                //You need to reset curr, as you are traversing curr to curr.Links and will point incorrectly if not reset back.
                curr = node;
                for (int j = i; j < str.Length; j++)
                {
                    if (!TrieNode.ContainsKey(curr, str[j]))
                    {
                        counter++;
                        curr.Links[str[j] - 'a'] = new TrieNode();
                    }

                    curr = curr.Links[str[j] - 'a'];
                }

                curr.IsEndOfWord = true;
            }

            // +1 for empty substring.
            return counter + 1;
        }
    }
}
