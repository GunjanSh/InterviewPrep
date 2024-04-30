using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tries
{
    internal class LongestCommonPrefix
    {
        public class TrieNode
        {
            public TrieNode[] Links = new TrieNode[26];

            public bool IsEndOfWord;

            public int PrefixCount;

            public static bool ContainsKey(TrieNode root, char ch)
            {
                return root.Links[ch - 'a'] != null;
            }
        }

        public static void FindLongestCommonPrefix()
        {
            var strs = new string[] { "flower", "flow", "flight" };

            var output = LongestCommonPrefixFunc(strs);
        }

        private static string LongestCommonPrefixFunc(string[] strs)
        {
            StringBuilder sb = new StringBuilder();
            TrieNode node = new TrieNode();

            foreach (var str in strs)
            {
                TrieNode root = node;

                foreach (var ch in str)
                {
                    if (!TrieNode.ContainsKey(root, ch))
                    {
                        root.Links[ch - 'a'] = new TrieNode();
                    }

                    root = root.Links[ch - 'a'];
                    root.PrefixCount++;

                    Console.WriteLine("Count: {0}", root.PrefixCount);
                }

                root.IsEndOfWord = true;
            }

            TrieNode currNode = node;

            foreach (var ch in strs[0])
            {
                if (currNode.Links[ch - 'a'].PrefixCount == strs.Length)
                {
                    sb.Append(ch);
                    currNode = currNode.Links[ch - 'a'];
                }
                else
                {
                    break;
                }
            }

            return sb.ToString();
        }
    }
}
